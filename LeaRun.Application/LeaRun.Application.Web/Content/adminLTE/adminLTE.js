(function (n, t) {
    "use strict";
    function r(n, t) {
        var r, u, i;
        try {
            if (r = "", u = t.length, u == undefined) r = t[n];
            else for (i = 0; i < u; i++) if (n(t[i])) {
                r = t[i];
                break
            }
            return r
        } catch (f) {
            return console.log(f.message),
            ""
        }
    }
    function u() {
        if (i.excelImportTemplate==undefined) {
            return
        }
        n.each(i.excelImportTemplate,
        function (n, t) {
            i.excelImportTemplate[n] = {
                keys: t
            }
        })
    }
    var i = {};
    t.data = {
        init: function (t) {
            n.ajax({
                url: contentPath + "/ClientData/GetClientDataJson",
                type: "post",
                dataType: "json",
                async: !0,
                success: function (r) {
                    i = r;
                    u();
                    t();
                    window.setTimeout(function () {
                        n("#ajax-loader").fadeOut()
                    },
                    50)
                }
            })
        },
        get: function (n) {
            var u;
            if (!n) return "";
            var e = n.length,
            t = "",
            f = i;
            for (u = 0; u < e; u++) if (t = r(n[u], f), t != "" && t != undefined) f = t;
            else break;
            return (t == undefined || t == null) && (t = ""),
            t
        }
    }

})(window.jQuery, window.learun);
var tablist = {
    newTab: function (n) {
        var i = n.id,
        t = n.url,
        e = n.title,
        r = !0,
        u, f;
        if (t == undefined || $.trim(t).length == 0) return !1;
        $(".menuTab").each(function () {
            if ($(this).data("id") == t) return $(this).hasClass("active") || ($(this).addClass("active").siblings(".menuTab").removeClass("active"), $.learuntab.scrollToTab(this), $(".mainContent .LRADMS_iframe").each(function () {
                if ($(this).data("id") == t) return $(this).show().siblings(".LRADMS_iframe").hide(),
                !1
            })),
            r = !1,
            !1
        });
        r && (u = '<a href="javascript:;" class="active menuTab" data-id="' + t + '">' + e + ' <i class="fa fa-remove"><\/i><\/a>', $(".menuTab").removeClass("active"), f = '<iframe class="LRADMS_iframe" id="iframe' + i + '" name="iframe' + i + '"  width="100%" height="100%" src="' + t + '" frameborder="0" data-id="' + t + '" seamless><\/iframe>', $(".mainContent").find("iframe.LRADMS_iframe").hide(), $(".mainContent").append(f), learun.loading({
            isShow: !0
        }), $(".mainContent iframe:visible").load(function () {
            learun.loading({
                isShow: !1
            })
        }), $(".menuTabs .page-tabs-content").append(u), $.learuntab.scrollToTab($(".menuTab.active")))
    }
}; (function (n) {
    n.learuntab = {
        requestFullScreen: function () {
            var n = document.documentElement;
            n.requestFullscreen ? n.requestFullscreen() : n.mozRequestFullScreen ? n.mozRequestFullScreen() : n.webkitRequestFullScreen && n.webkitRequestFullScreen()
        },
        exitFullscreen: function () {
            var n = document;
            n.exitFullscreen ? n.exitFullscreen() : n.mozCancelFullScreen ? n.mozCancelFullScreen() : n.webkitCancelFullScreen && n.webkitCancelFullScreen()
        },
        refreshTab: function () {
            var i = n(".page-tabs-content").find(".active").attr("data-id"),
            t = n('.LRADMS_iframe[data-id="' + i + '"]'),
            r = t.attr("src");
            learun.loading({
                isShow: !0
            });
            t.attr("src", r).load(function () {
                learun.loading({
                    isShow: !1
                })
            })
        },
        activeTab: function () {
            var i = n(this).data("id"),
            t;
            n(this).hasClass("active") || (n(".mainContent .LRADMS_iframe").each(function () {
                if (n(this).data("id") == i) return n(this).show().siblings(".LRADMS_iframe").hide(),
                !1
            }), n(this).addClass("active").siblings(".menuTab").removeClass("active"), n.learuntab.scrollToTab(this));
            t = n(this).attr("data-value");
            t != "" && top.$.cookie("currentmoduleId", t, {
                path: "/"
            })
        },
        closeOtherTabs: function () {
            n(".page-tabs-content").children("[data-id]").find(".fa-remove").parents("a").not(".active").each(function () {
                n('.LRADMS_iframe[data-id="' + n(this).data("id") + '"]').remove();
                n(this).remove()
            });
            n(".page-tabs-content").css("margin-left", "0")
        },
        closeTab: function () {
            var i = n(this).parents(".menuTab").data("id"),
            f = n(this).parents(".menuTab").width(),
            r,
            t,
            u;
            return n(this).parents(".menuTab").hasClass("active") ? (n(this).parents(".menuTab").next(".menuTab").size() && (t = n(this).parents(".menuTab").next(".menuTab:eq(0)").data("id"), n(this).parents(".menuTab").next(".menuTab:eq(0)").addClass("active"), n(".mainContent .LRADMS_iframe").each(function () {
                if (n(this).data("id") == t) return n(this).show().siblings(".LRADMS_iframe").hide(),
                !1
            }), r = parseInt(n(".page-tabs-content").css("margin-left")), r < 0 && n(".page-tabs-content").animate({
                marginLeft: r + f + "px"
            },
            "fast"), n(this).parents(".menuTab").remove(), n(".mainContent .LRADMS_iframe").each(function () {
                if (n(this).data("id") == i) return n(this).remove(),
                !1
            })), n(this).parents(".menuTab").prev(".menuTab").size() && (t = n(this).parents(".menuTab").prev(".menuTab:last").data("id"), n(this).parents(".menuTab").prev(".menuTab:last").addClass("active"), n(".mainContent .LRADMS_iframe").each(function () {
                if (n(this).data("id") == t) return n(this).show().siblings(".LRADMS_iframe").hide(),
                !1
            }), n(this).parents(".menuTab").remove(), n(".mainContent .LRADMS_iframe").each(function () {
                if (n(this).data("id") == i) return n(this).remove(),
                !1
            }))) : (n(this).parents(".menuTab").remove(), n(".mainContent .LRADMS_iframe").each(function () {
                if (n(this).data("id") == i) return n(this).remove(),
                !1
            }), n.learuntab.scrollToTab(n(".menuTab.active"))),
            u = n(".menuTab.active").attr("data-value"),
            u != "" && top.$.cookie("currentmoduleId", u, {
                path: "/"
            }),
            !1
        },
        addTab: function () {
            var i, u, f;
            n(".navbar-custom-menu>ul>li.open").removeClass("open");
            i = n(this).attr("data-id");
            i != "" && top.$.cookie("currentmoduleId", i, {
                path: "/"
            });
            var t = n(this).attr("href"),
            e = n.trim(n(this).text()),
            r = !0;
            return t == undefined || n.trim(t).length == 0 ? !1 : (n(".menuTab").each(function () {
                if (n(this).data("id") == t) return n(this).hasClass("active") || (n(this).addClass("active").siblings(".menuTab").removeClass("active"), n.learuntab.scrollToTab(this), n(".mainContent .LRADMS_iframe").each(function () {
                    if (n(this).data("id") == t) return n(this).show().siblings(".LRADMS_iframe").hide(),
                    !1
                })),
                r = !1,
                !1
            }), r && (u = '<a href="javascript:;" class="active menuTab" data-value=' + i + ' data-id="' + t + '">' + e + ' <i class="fa fa-remove"><\/i><\/a>', n(".menuTab").removeClass("active"), f = '<iframe class="LRADMS_iframe" id="iframe' + i + '" name="iframe' + i + '"  width="100%" height="100%" src="' + t + '" frameborder="0" data-id="' + t + '" seamless><\/iframe>', n(".mainContent").find("iframe.LRADMS_iframe").hide(), n(".mainContent").append(f), learun.loading({
                isShow: !0
            }), n(".mainContent iframe:visible").load(function () {
                learun.loading({
                    isShow: !1
                })
            }), n(".menuTabs .page-tabs-content").append(u), n.learuntab.scrollToTab(n(".menuTab.active"))), !1)
        },
        scrollTabRight: function () {
            var f = Math.abs(parseInt(n(".page-tabs-content").css("margin-left"))),
            e = n.learuntab.calSumWidth(n(".content-tabs").children().not(".menuTabs")),
            u = n(".content-tabs").outerWidth(!0) - e,
            r = 0,
            t,
            i;
            if (n(".page-tabs-content").width() < u) return !1;
            for (t = n(".menuTab:first"), i = 0; i + n(t).outerWidth(!0) <= f;) i += n(t).outerWidth(!0),
            t = n(t).next();
            for (i = 0; i + n(t).outerWidth(!0) < u && t.length > 0;) i += n(t).outerWidth(!0),
            t = n(t).next();
            r = n.learuntab.calSumWidth(n(t).prevAll());
            r > 0 && n(".page-tabs-content").animate({
                marginLeft: 0 - r + "px"
            },
            "fast")
        },
        scrollTabLeft: function () {
            var f = Math.abs(parseInt(n(".page-tabs-content").css("margin-left"))),
            e = n.learuntab.calSumWidth(n(".content-tabs").children().not(".menuTabs")),
            r = n(".content-tabs").outerWidth(!0) - e,
            u = 0,
            t,
            i;
            if (n(".page-tabs-content").width() < r) return !1;
            for (t = n(".menuTab:first"), i = 0; i + n(t).outerWidth(!0) <= f;) i += n(t).outerWidth(!0),
            t = n(t).next();
            if (i = 0, n.learuntab.calSumWidth(n(t).prevAll()) > r) {
                while (i + n(t).outerWidth(!0) < r && t.length > 0) i += n(t).outerWidth(!0),
                t = n(t).prev();
                u = n.learuntab.calSumWidth(n(t).prevAll())
            }
            n(".page-tabs-content").animate({
                marginLeft: 0 - u + "px"
            },
            "fast")
        },
        scrollToTab: function (t) {
            var f = n.learuntab.calSumWidth(n(t).prevAll()),
            e = n.learuntab.calSumWidth(n(t).nextAll()),
            o = n.learuntab.calSumWidth(n(".content-tabs").children().not(".menuTabs")),
            r = n(".content-tabs").outerWidth(!0) - o,
            i = 0,
            u;
            if (n(".page-tabs-content").outerWidth() < r) i = 0;
            else if (e <= r - n(t).outerWidth(!0) - n(t).next().outerWidth(!0)) {
                if (r - n(t).next().outerWidth(!0) > e) for (i = f, u = t; i - n(u).outerWidth() > n(".page-tabs-content").outerWidth() - r;) i -= n(u).prev().outerWidth(),
                u = n(u).prev()
            } else f > r - n(t).outerWidth(!0) - n(t).prev().outerWidth(!0) && (i = f - n(t).prev().outerWidth(!0));
            n(".page-tabs-content").animate({
                marginLeft: 0 - i + "px"
            },
            "fast")
        },
        calSumWidth: function (t) {
            var i = 0;
            return n(t).each(function () {
                i += n(this).outerWidth(!0)
            }),
            i
        },
        calSumHeight: function (t) {
            var i = 0;
            return n(t).each(function () {
                i += n(this).outerHeight(!0)
            }),
            i
        },
        init: function () {
            n(".menuItem").on("click", n.learuntab.addTab);
            n(".menuTabs").on("click", ".menuTab i", n.learuntab.closeTab);
            n(".menuTabs").on("click", ".menuTab", n.learuntab.activeTab);
            n(".tabLeft").on("click", n.learuntab.scrollTabLeft);
            n(".tabRight").on("click", n.learuntab.scrollTabRight);
            n(".tabReload").on("click", n.learuntab.refreshTab);
            n(".tabCloseCurrent").on("click",
            function () {
                n(".page-tabs-content").find(".active i").trigger("click")
            });
            n(".tabCloseAll").on("click",
            function () {
                n(".page-tabs-content").children("[data-id]").find(".fa-remove").each(function () {
                    n('.LRADMS_iframe[data-id="' + n(this).data("id") + '"]').remove();
                    n(this).parents("a").remove()
                });
                n(".page-tabs-content").children("[data-id]:first").each(function () {
                    n('.LRADMS_iframe[data-id="' + n(this).data("id") + '"]').show();
                    n(this).addClass("active")
                });
                n(".page-tabs-content").css("margin-left", "0")
            });
            n(".tabCloseOther").on("click", n.learuntab.closeOtherTabs);
            n(".fullscreen").on("click",
            function () {
                n(this).attr("fullscreen") ? (n(this).removeAttr("fullscreen"), n.learuntab.exitFullscreen()) : (n(this).attr("fullscreen", "true"), n.learuntab.requestFullScreen())
            })
        }
    };
    n.learunindex = {
        load: function () {
            n("body").removeClass("hold-transition");
            n("#content-wrapper").find(".mainContent").height(n(window).height() - 90);
            n("#sidebar-menu").height(n(window).height() - 150);
            n(window).resize(function () {
                n("#content-wrapper").find(".mainContent").height(n(window).height() - 90);
                n("#sidebar-menu").height(n(window).height() - 150)
            });
            n(".sidebar-toggle").click(function () {
                n("body").hasClass("sidebar-collapse") ? (n("body").removeClass("sidebar-collapse"), n("#sidebar-menu").removeClass("sidebar-menu2")) : (n("body").addClass("sidebar-collapse"), n("#sidebar-menu").addClass("sidebar-menu2"))
            })
        },
        jsonWhere: function (t, i) {
            if (i != null) {
                var r = [];
                return n(t).each(function (n, t) {
                    i(t) && r.push(t)
                }),
                r
            }
        },
        loadMenu: function () {
            var i = top.learun.data.get(["authorizeMenu"]),
            t = "";
            n.each(i,
            function (r) {
                var u = i[r],
                f;
                u.ParentId == "0" && (t += r == 0 ? '<li class="treeview active">' : '<li class="treeview">', t += '<a href="#">', t += '<i class="' + u.Icon + '"><\/i><span>' + u.FullName + '<\/span><i class="fa fa-angle-left pull-right"><\/i>', t += "<\/a>", f = n.learunindex.jsonWhere(i,
                function (n) {
                    return n.ParentId == u.ModuleId
                }), f.length > 0 && (t += '<ul class="treeview-menu">', n.each(f,
                function (r) {
                    var u = f[r],
                    e = n.learunindex.jsonWhere(i,
                    function (n) {
                        return n.ParentId == u.ModuleId
                    });
                    t += "<li>";
                    e.length > 0 ? (t += '<a href="#"><i class="' + u.Icon + '"><\/i>' + u.FullName + "", t += '<i class="fa fa-angle-left pull-right"><\/i><\/a>', t += '<ul class="treeview-menu">', n.each(e,
                    function (n) {
                        var i = e[n];
                        t += '<li><a class="menuItem" data-id="' + i.ModuleId + '" href="' + i.UrlAddress + '"><i class="' + i.Icon + '"><\/i>' + i.FullName + "<\/a><\/li>"
                    }), t += "<\/ul>") : t += '<a class="menuItem" data-id="' + u.ModuleId + '" href="' + u.UrlAddress + '"><i class="' + u.Icon + '"><\/i>' + u.FullName + "<\/a>";
                    t += "<\/li>"
                }), t += "<\/ul>"), t += "<\/li>")
            });
            n("#sidebar-menu").append(t);
            n("#sidebar-menu li a").click(function () {
                var i = n(this),
                t = i.next(),
                r,
                u,
                f,
                e;
                t.is(".treeview-menu") && t.is(":visible") ? (t.slideUp(500,
                function () {
                    t.removeClass("menu-open")
                }), t.parent("li").removeClass("active")) : t.is(".treeview-menu") && !t.is(":visible") && (r = i.parents("ul").first(), u = r.find("ul:visible").slideUp(500), u.removeClass("menu-open"), f = i.parent("li"), e = n.learuntab.calSumHeight(n("#sidebar-menu>li")), t.slideDown(500,
                function () {
                    var i, u;
                    t.addClass("menu-open");
                    r.find("li.active").removeClass("active");
                    f.addClass("active");
                    try {
                        i = n(window).height() - n("#sidebar-menu >li.active").position().top - 41
                    } catch (t) { }
                    u = n("#sidebar-menu li > ul.menu-open").height() + 10;
                    u > i ? e < n("#sidebar-menu").height() ? i > 70 ? n("#sidebar-menu >li > ul.menu-open").css({
                        overflow: "auto",
                        height: i
                    }) : n("#sidebar-menu >li > ul.menu-open").css({
                        overflow: "initial",
                        height: "initial"
                    }) : n("#sidebar-menu >li > ul.menu-open").css({
                        overflow: "initial",
                        height: "initial"
                    }) : n("#sidebar-menu >li > ul.menu-open").css({
                        overflow: "initial",
                        height: "initial"
                    })
                }));
                t.is(".treeview-menu")
            })
        },
        indexOut: function () {
            dialogConfirm("注：您确定要安全退出本次登录吗？",
            function (t) {
                t && (learun.loading({
                    isShow: !0,
                    text: "正在安全退出..."
                }), window.setTimeout(function () {
                    n.ajax({
                        url: contentPath + "/Login/OutLogin",
                        type: "post",
                        dataType: "json",
                        success: function () {
                            window.location.href = contentPath + "/Login/Index"
                        }
                    })
                },
                500))
            })
        }
    };
    n(function () {
        learun.init({
            callBack: function () {
                n.learunindex.loadMenu();
                n.learuntab.init();
                n.learunindex.load()
            },
            themeType: "2"
        })
    })
})(jQuery)