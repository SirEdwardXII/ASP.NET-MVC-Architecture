
window.$layout = {
    window: $(window),
    nav: {
        headerTag: $("header"),
        headerDiv: $(".nav-header"),
        button: $(".nav-button"),
        transition: $(".button-trans"),
        collapse: $(".nav-collapse"),
        menuOptions: $(".nav-menu-option"),
        delayTimer: null
    },
    scroll: {
        currentPosition: 0,
        direction: null,
        headerHeight: 50,
        windowHeight: $(window).height()
    },
    breakpoint: {
        current: "",
        previous: "",
        devices: {
            xs: $(".device-xs"),
            sm: $(".device-sm"),
            md: $(".device-md"),
            lg: $(".device-lg")
        }
    },
    topics: {
        imageLeftRight: $(".title-topic.image-right-left"),
        background: $(".title-topic.background"),
        imageBottom: $(".title-topic.image-bottom"),
        all: $(".title-topic")
    },
    linkLine: {
        links: $(".link-line")
    }
};

$(function () {
    // control header navigation
    $layout.nav.button.on("click", function () {
        clearTimeout($layout.nav.delayTimer);

        if ($layout.nav.transition.hasClass("open")) {
            $layout.nav.transition.removeClass("open");
            $layout.nav.collapse.removeClass("nav-opened");
            $layout.nav.collapse.addClass("nav-collapsed");

            $layout.nav.delayTimer = setTimeout(function () {
                $layout.nav.headerDiv.removeClass("nav-opened");
                $layout.nav.collapse.removeClass("nav-collapsed");
                $layout.nav.menuOptions.removeClass("slide");
            }, 500);
        } else {
            $layout.nav.headerDiv.addClass("nav-opened");
            $layout.nav.transition.addClass("open");
            $layout.nav.collapse.removeClass("nav-collapsed");
            $layout.nav.collapse.addClass("nav-opened");

            $layout.nav.menuOptions.each(function (index, obj) {
                setTimeout(function () {
                    $(obj).addClass("slide");
                }, index * 50);
            });
        }
    });

    // set the initial value for the breakpoints
    $layout.breakpoint.current = currentBreakpoint();
    $layout.breakpoint.previous = $layout.breakpoint.current;

    // resize events
    $layout.window.on("resize", function (resizeEvent) {
        // determine the current breakpoint
        var breakpoint = currentBreakpoint();
        if (breakpoint != $layout.breakpoint.current) {
            $layout.breakpoint.previous = $layout.breakpoint.current;
            $layout.breakpoint.current = breakpoint;
        }

    });

    // scroll events
    $layout.window.on("scroll", function (scrollEvent) {
        var scrollTop = $layout.window.scrollTop();
        if (scrollTop >= $layout.scroll.currentPosition)
            $layout.scroll.direction = "down";
        else
            $layout.scroll.direction = "up";
        $layout.scroll.currentPosition = scrollTop;

        // navbar
        updateNavbarScroll();

        // topics
        updateTopicsByScroll();

        // link lines
        updateLinkLines();
    });
});

function updateNavbarScroll() {
    if ($layout.scroll.currentPosition < 0) {
        $layout.nav.headerTag.stop().removeClass("fixed").removeClass("body-position").css("top", "0px");
    } else {

        if ($layout.scroll.direction == "down") {
            // when we scroll down, we leave the top position where it is and allow the navbar to scroll off screen
            //console.log("down");

            if ($layout.nav.headerTag.hasClass("fixed")) {
                $layout.nav.headerTag.stop().removeClass("fixed").css("top", $layout.scroll.currentPosition + "px");
            }
        } else {
            // when we scroll up, we allow the navbar to scroll back into position, and then fix it at the top of the screen
            //console.log("up");

            // find out where the navbar is
            var headerPos = $layout.nav.headerTag.position();

            // begin by checking to see if the navbar is already fixed
            if ($layout.nav.headerTag.hasClass("fixed")) {
                // the header is already fixed - find out if we should remove the fixed setting
                if ($layout.scroll.currentPosition < 10) {
                    $layout.nav.headerTag.stop().removeClass("fixed").removeClass("body-position").css("top", "0px");
                } else {
                    $layout.nav.headerTag.stop().css("top", $layout.scroll.currentPosition + "px");
                }
            } else {
                if ($layout.scroll.currentPosition > headerPos.top + $layout.scroll.headerHeight) {
                    // move the scrollbar
                    $layout.nav.headerTag.stop().addClass("body-position").css("top", $layout.scroll.currentPosition - $layout.scroll.headerHeight);
                } else if ($layout.scroll.currentPosition < headerPos.top) {
                    // add the fixed class
                    $layout.nav.headerTag.addClass("fixed").css("top", $layout.scroll.currentPosition + "px");
                }
            }
        }
    }
}

function updateTopicsByScroll() {
    // topics do some animation, but only on md or lg screens
    if ($layout.breakpoint.current == "md" || $layout.breakpoint.current == "lg") {
        // make sure the item has the prep class
        $layout.topics.all.addClass("anim-prep");

        var topicObj;

        // image left / right
        $.each($layout.topics.all, function (index, obj) {
            topicObj = $(obj);
            if (!topicObj.hasClass("anim-play")) {
                var position = topicObj.position();

                if (position.top < $layout.scroll.currentPosition + ($layout.scroll.windowHeight * 0.5)) {
                    topicObj.addClass("anim-play");
                }
            }
        });
    }
}

function updateLinkLines() {
    $.each($layout.linkLine.links, function (linkIndex, linkObj) {
        var self = $(linkObj);
        if (!self.hasClass("link")) {
            var position = self.position();

            if (position.top < $layout.scroll.currentPosition + ($layout.scroll.windowHeight * 1)) {
                self.addClass("link");
            }
        }
    });
}


// #################################################
// Utilities

function currentBreakpoint() {
    if (isBreakpoint("xs"))
        return "xs";
    if (isBreakpoint("sm"))
        return "sm";
    if (isBreakpoint("md"))
        return "md";
    if (isBreakpoint("lg"))
        return "lg";
}

function isBreakpoint(alias) {
    switch (alias) {
        case "xs":
            return $layout.breakpoint.devices.xs.is(":visible");
            break;
        case "sm":
            return $layout.breakpoint.devices.sm.is(":visible");
            break;
        case "md":
            return $layout.breakpoint.devices.md.is(":visible");
            break;
        case "lg":
            return $layout.breakpoint.devices.lg.is(":visible");
            break;
    }
}