!(function (e) {
    e(window).on("load", function () {
        e(".preloader").fadeOut();
    }),
        e(".preloader").length > 0 &&
        e(".preloaderCls").each(function () {
            e(this).on("click", function (t) {
                t.preventDefault(), e(".preloader").css("display", "none");
            });
        }),
        (e.fn.vsmobilemenu = function (t) {
            var s = e.extend(
                {
                    menuToggleBtn: ".vs-menu-toggle",
                    bodyToggleClass: "vs-body-visible",
                    subMenuClass: "vs-submenu",
                    subMenuParent: "vs-item-has-children",
                    subMenuParentToggle: "vs-active",
                    meanExpandClass: "vs-mean-expand",
                    appendElement: '<span class="vs-mean-expand"></span>',
                    subMenuToggleClass: "vs-open",
                    toggleSpeed: 400,
                },
                t
            );
            return this.each(function () {
                var t = e(this);
                function a() {
                    t.toggleClass(s.bodyToggleClass),
                        e("." + s.subMenuClass).each(function () {
                            e(this).hasClass(s.subMenuToggleClass) && (e(this).removeClass(s.subMenuToggleClass), e(this).css("display", "none"), e(this).parent().removeClass(s.subMenuParentToggle));
                        });
                }
                t.find("li").each(function () {
                    var t = e(this).find("ul");
                    t.addClass(s.subMenuClass), t.css("display", "none"), t.parent().addClass(s.subMenuParent), t.prev("a").append(s.appendElement), t.next("a").append(s.appendElement);
                }),
                    e("." + s.meanExpandClass).each(function () {
                        e(this).on("click", function (t) {
                            var a;
                            t.preventDefault(),
                                (a = e(this).parent()),
                                e(a).next("ul").length > 0
                                    ? (e(a).parent().toggleClass(s.subMenuParentToggle), e(a).next("ul").slideToggle(s.toggleSpeed), e(a).next("ul").toggleClass(s.subMenuToggleClass))
                                    : e(a).prev("ul").length > 0 && (e(a).parent().toggleClass(s.subMenuParentToggle), e(a).prev("ul").slideToggle(s.toggleSpeed), e(a).prev("ul").toggleClass(s.subMenuToggleClass));
                        });
                    }),
                    e(s.menuToggleBtn).each(function () {
                        e(this).on("click", function () {
                            a();
                        });
                    }),
                    t.on("click", function (e) {
                        e.stopPropagation(), a();
                    }),
                    t.find("div").on("click", function (e) {
                        e.stopPropagation();
                    });
            });
        }),
        e(".vs-menu-wrapper").vsmobilemenu();
    var t = "",
        s = ".scrollToTop";
    e(window).on("scroll", function () {
        var a, n, o, l, i;
        (a = e(".sticky-active")),
            (n = "active"),
            (o = "will-sticky"),
            (l = e(window).scrollTop()),
            (i = a.css("height")),
            a.parent().css("min-height", i),
            e(window).scrollTop() > 5800 ? (a.parent().addClass(o), l > t ? a.removeClass(n) : a.addClass(n)) : (a.parent().css("min-height", "").removeClass(o), a.removeClass(n)),
            (t = l),
            e(this).scrollTop() > 500 ? e(s).addClass("show") : e(s).removeClass("show");
    }),
        e(s).each(function () {
            e(this).on("click", function (s) {
                return s.preventDefault(), e("html, body").animate({ scrollTop: 0 }, t / 3), !1;
            });
        }),
        e("[data-bg-src]").length > 0 &&
        e("[data-bg-src]").each(function () {
            var t = e(this).attr("data-bg-src");
            e(this).css("background-image", "url(" + t + ")"), e(this).removeAttr("data-bg-src").addClass("background-image");
        }),
        e(".vs-hero-carousel").each(function () {
            var t = e(this);
            function s(e) {
                return t.data(e);
            }
            t
                .on("sliderDidLoad", function (s, a) {
                    var n = ".ls-custom-dot",
                        o = "data-slide-go",
                        l = a.slides.current.index,
                        i = 1;
                    e(n).each(function () {
                        e(this).attr(o, i),
                            i++,
                            e(this).on("click", function (s) {
                                s.preventDefault();
                                var a = e(this).attr(o);
                                t.layerSlider(parseFloat(a));
                            });
                    }),
                        setTimeout(() => {
                            t.find(".ls-custom-arrow").each(function () {
                                e(this).on("click", function (s) {
                                    s.preventDefault();
                                    var a = e(this).attr("data-change-slide");
                                    t.layerSlider(a);
                                });
                            });
                        }, 1e3),
                        e(n + "[" + o + '="' + l + '"').addClass("active");
                })
                .on("slideChangeDidComplete", function (t, s) {
                    e('.ls-custom-dot[data-slide-go="' + s.slides.current.index + '"')
                        .addClass("active")
                        .siblings()
                        .removeClass("active");
                }),
                t.layerSlider({
                    allowFullscreen: !!s("allowfullscreen"),
                    allowRestartOnResize: !0,
                    maxRatio: s("maxratio") ? s("maxratio") : 1,
                    type: s("slidertype") ? s("slidertype") : "responsive",
                    pauseOnHover: !!s("pauseonhover"),
                    navPrevNext: !!s("navprevnext"),
                    hoverPrevNext: !!s("hoverprevnext"),
                    hoverBottomNav: !!s("hoverbottomnav"),
                    navStartStop: !!s("navstartstop"),
                    navButtons: !!s("navbuttons"),
                    loop: !1 !== s("loop"),
                    autostart: !!s("autostart"),
                    height: s("height") ? s("height") : 1080,
                    responsiveUnder: s("responsiveunder") ? s("responsiveunder") : 1220,
                    layersContainer: s("container") ? s("container") : 1220,
                    showCircleTimer: !!s("showcircletimer"),
                    skinsPath: "layerslider/skins/",
                    thumbnailNavigation: !1 !== s("thumbnailnavigation"),
                });
        }),
        e(".vs-carousel").each(function () {
            var t = e(this);
            function s(e) {
                return t.data(e);
            }
            var a = '<button type="button" class="slick-prev"><i class="' + s("prev-arrow") + '"></i></button>',
                n = '<button type="button" class="slick-next"><i class="' + s("next-arrow") + '"></i></button>';
            e("[data-slick-next]").each(function () {
                e(this).on("click", function (t) {
                    t.preventDefault(), e(e(this).data("slick-next")).slick("slickNext");
                });
            }),
                e("[data-slick-prev]").each(function () {
                    e(this).on("click", function (t) {
                        t.preventDefault(), e(e(this).data("slick-prev")).slick("slickPrev");
                    });
                }),
                1 == s("arrows") && (t.closest(".arrow-wrap").length || t.closest(".container").parent().addClass("arrow-wrap")),
                t.slick({
                    dots: !!s("dots"),
                    fade: !!s("fade"),
                    arrows: !!s("arrows"),
                    speed: s("speed") ? s("speed") : 1e3,
                    asNavFor: !!s("asnavfor") && s("asnavfor"),
                    autoplay: 0 != s("autoplay"),
                    infinite: 0 != s("infinite"),
                    slidesToShow: s("slide-show") ? s("slide-show") : 1,
                    adaptiveHeight: !!s("adaptive-height"),
                    centerMode: !!s("center-mode"),
                    autoplaySpeed: s("autoplay-speed") ? s("autoplay-speed") : 8e3,
                    centerPadding: s("center-padding") ? s("center-padding") : "0",
                    focusOnSelect: !!s("focuson-select"),
                    pauseOnFocus: !!s("pauseon-focus"),
                    pauseOnHover: !!s("pauseon-hover"),
                    variableWidth: !!s("variable-width"),
                    vertical: !!s("vertical"),
                    verticalSwiping: !!s("vertical"),
                    prevArrow: s("prev-arrow") ? a : '<button type="button" class="slick-prev"><i class="fal fa-long-arrow-left"></i></button>',
                    nextArrow: s("next-arrow") ? n : '<button type="button" class="slick-next"><i class="fal fa-long-arrow-right"></i></button>',
                    rtl: "rtl" == e("html").attr("dir"),
                    responsive: [
                        { breakpoint: 1600, settings: { arrows: !!s("xl-arrows"), dots: !!s("xl-dots"), slidesToShow: s(s("xl-slide-show") ? "xl-slide-show" : "slide-show"), centerMode: !!s("xl-center-mode"), centerPadding: 0 } },
                        { breakpoint: 1400, settings: { arrows: !!s("ml-arrows"), dots: !!s("ml-dots"), slidesToShow: s(s("ml-slide-show") ? "ml-slide-show" : "slide-show"), centerMode: !!s("ml-center-mode"), centerPadding: 0 } },
                        {
                            breakpoint: 1200,
                            settings: { arrows: !!s("lg-arrows"), dots: !!s("lg-dots"), slidesToShow: s(s("lg-slide-show") ? "lg-slide-show" : "slide-show"), centerMode: !!s("lg-center-mode") && s("lg-center-mode"), centerPadding: 0 },
                        },
                        {
                            breakpoint: 992,
                            settings: { arrows: !!s("md-arrows"), dots: !!s("md-dots"), slidesToShow: s("md-slide-show") ? s("md-slide-show") : 1, centerMode: !!s("md-center-mode") && s("md-center-mode"), centerPadding: 0 },
                        },
                        {
                            breakpoint: 767,
                            settings: { arrows: !!s("sm-arrows"), dots: !!s("sm-dots"), slidesToShow: s("sm-slide-show") ? s("sm-slide-show") : 1, centerMode: !!s("sm-center-mode") && s("sm-center-mode"), centerPadding: 0 },
                        },
                        {
                            breakpoint: 576,
                            settings: { arrows: !!s("xs-arrows"), dots: !!s("xs-dots"), slidesToShow: s("xs-slide-show") ? s("xs-slide-show") : 1, centerMode: !!s("xs-center-mode") && s("xs-center-mode"), centerPadding: 0 },
                        },
                    ],
                });
        });
    var a = ".ajax-contact",
        n = "is-invalid",
        o = '[name="email"]',
        l = e(".form-messages");
    function i(e) {
        return parseInt(e, 10);
    }
    e(a).on("submit", function (t) {
        var s, i, r, c;
        t.preventDefault(),
            (i = e(a).serialize()),
            (s =
                ((c = !0),
                    (function t(s) {
                        s = s.split(",");
                        for (var o = 0; o < s.length; o++) e((r = a + " " + s[o])).val() ? (e(r).removeClass(n), (c = !0)) : (e(r).addClass(n), (c = !1));
                    })('[name="name"],[name="email"],[name="number"],[name="subject"],[name="message"]'),
                    e(o).val() &&
                        e(o)
                            .val()
                            .match(/^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/)
                        ? (e(o).removeClass(n), (c = !0))
                        : (e(o).addClass(n), (c = !1)),
                    c)) &&
            jQuery
                .ajax({ url: e(a).attr("action"), data: i, type: "POST" })
                .done(function (t) {
                    l.removeClass("error"), l.addClass("success"), l.text(t), e(a + ' input:not([type="submit"]),' + a + " textarea").val("");
                })
                .fail(function (e) {
                    l.removeClass("success"), l.addClass("error"), "" !== e.responseText ? l.html(e.responseText) : l.html("Oops! An error occured and your message could not be sent.");
                });
    }),
        e(".popup-image").magnificPopup({ type: "image", gallery: { enabled: !0 } }),
        e(".popup-video").magnificPopup({ type: "iframe" }),
        (e.fn.sectionPosition = function (t, s, a) {
            e(this).each(function () {
                var n,
                    o,
                    l,
                    r,
                    c,
                    d,
                    u = e(this);
                (n = Math.floor(u.height() / 2)),
                    (o = i(u.attr(a))),
                    (l = u.attr(t)),
                    (c = i(e((r = u.attr(s))).css("padding-top"))),
                    (d = i(e(r).css("padding-bottom"))),
                    "top-half" === l
                        ? (e(r).css("padding-bottom", d + n + "px"), u.css("margin-top", "-" + n + "px"))
                        : "bottom-half" === l
                            ? (e(r).css("padding-top", c + n + "px"), u.css("margin-bottom", "-" + n + "px"))
                            : "top" === l
                                ? (e(r).css("padding-bottom", d + o + "px"), u.css("margin-top", "-" + o + "px"))
                                : "bottom" === l && (e(r).css("padding-top", c + o + "px"), u.css("margin-bottom", "-" + o + "px"));
            });
        });
    var r = "[data-sec-pos]";
    e(r).length &&
        e(r).imagesLoaded(function () {
            e(r).sectionPosition("data-sec-pos", "data-pos-for", "data-pos-amount");
        }),
        e(".filter-active").imagesLoaded(function () {
            var t = ".filter-active",
                s = ".filter-menu-active";
            if (e(t).length > 0) {
                var a = e(t).isotope({ itemSelector: ".filter-item", filter: "*", masonry: { columnWidth: 1 } });
                e(s).on("click", "button", function () {
                    var t = e(this).attr("data-filter");
                    a.isotope({ filter: t });
                }),
                    e(s).on("click", "button", function (t) {
                        t.preventDefault(), e(this).addClass("active"), e(this).siblings(".active").removeClass("active");
                    });
            }
        }),
        (e.fn.vsTab = function (t) {
            var s = e.extend({ sliderTab: !1, tabButton: "button", indicator: !1 }, t);
            e(this).each(function () {
                var t = e(this),
                    a = t.find(s.tabButton);
                if (
                    (a.on("click", function (t) {
                        t.preventDefault();
                        var a = e(this);
                        a.addClass("active").siblings().removeClass("active"), s.sliderTab && e(n).slick("slickGoTo", a.data("slide-go-to"));
                    }),
                        s.sliderTab)
                ) {
                    var n = t.data("asnavfor"),
                        o = 0;
                    a.each(function () {
                        var a = e(this);
                        a.attr("data-slide-go-to", o),
                            o++,
                            a.hasClass("active") && e(n).slick("slickGoTo", a.data("slide-go-to")),
                            e(n).on("beforeChange", function (e, a, n, o) {
                                t.find(s.tabButton + '[data-slide-go-to="' + o + '"]')
                                    .addClass("active")
                                    .siblings()
                                    .removeClass("active");
                            });
                    });
                }
            });
        }),
        e(".vs-slider-tab").length && e(".vs-slider-tab").vsTab({ sliderTab: !0, tabButton: ".tab-btn" }),
        e(".accordion-button").each(function () {
            e(this).on("click", function () {
                e(this).closest(".accordion-item").toggleClass("active").siblings().removeClass("active");
            });
        });
})(jQuery),
    $(".tab-menu a").click(function (e) {
        e.preventDefault(), $(this).tab("show");
    });
var modal = document.getElementById("myModal"),
    btn = document.getElementById("myBtn"),
    span = document.getElementsByClassName("close")[0];
(btn.onclick = function () {
    modal.style.display = "block";
}),
    (span.onclick = function () {
        modal.style.display = "none";
    }),
    (window.onclick = function (e) {
        e.target == modal && (modal.style.display = "none");
    });
var modal = document.getElementById("myModal"),
    btn = document.getElementById("myBtn1"),
    span = document.getElementsByClassName("close")[0];
(btn.onclick = function () {
    modal.style.display = "block";
}),
    (span.onclick = function () {
        modal.style.display = "none";
    }),
    (window.onclick = function (e) {
        e.target == modal && (modal.style.display = "none");
    });
var sorgulamaModal = document.getElementById("basvuruSorgulamaModel"),
    btn = document.getElementById("sorgulamaButton"),
    span = document.getElementsByClassName("kapat")[0];
(btn.onclick = function () {
    sorgulamaModal.style.display = "block";
}),
    (span.onclick = function () {
        sorgulamaModal.style.display = "none";
    }),
    (window.onclick = function (e) {
        e.target == sorgulamaModal && (sorgulamaModal.style.display = "none");
    });
var sorgulamaModal = document.getElementById("basvuruSorgulamaModel"),
    btn = document.getElementById("sorgulamaButtonMobile"),
    span = document.getElementsByClassName("kapat")[0];
(btn.onclick = function () {
    sorgulamaModal.style.display = "block";
}),
    (span.onclick = function () {
        sorgulamaModal.style.display = "none";
    }),
    (window.onclick = function (e) {
        e.target == sorgulamaModal && (sorgulamaModal.style.display = "none");
    });



