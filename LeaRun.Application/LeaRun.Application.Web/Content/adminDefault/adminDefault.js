function IndexOut() {
    learun.dialogConfirm({
        msg: "注：您确定要安全退出本次登录吗？",
        callBack: function (n) {
            n && (learun.loading({
                isShow: !0,
                text: "正在安全退出..."
            }), window.setTimeout(function () {
                $.ajax({
                    url: contentPath + "/Login/OutLogin",
                    type: "post",
                    dataType: "json",
                    success: function () {
                        window.location.href = contentPath + "/Login/Index"
                    }
                })
            },
            500))
        }
    })
} (function (n, t) {
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
$.fn.Tab = function (n) {
    function a(n) {
        i.find("#" + n.id).parents("li").remove();
        r.find("#iframe" + n.id).remove()
    }
    function h(n) {
        var e, u, f;
        if (n == null) return !1;
        n.replace == !0 && a(n);
        i.find("#" + n.id).length == 0 ? (learun.loading({
            isShow: !0
        }), e = l.replace("{0}", n.id).replace("{1}", n.title).replace("{2}", n.icon).replace("{3}", n.dataValue), u = $('<li class="off"><\/li>'), u.append(e).appendTo(i.find("ul")).find("table td:eq(1)").click(function () {
            if (u.contextmenu(), !u.hasClass(t.tabClassOn)) {
                var n = u.parent().find("li." + t.tabClassOn);
                n.removeClass().addClass(t.tabClassOff);
                $(this).next().find("div").removeClass().addClass(t.tabClassClose);
                u.removeClass().addClass(t.tabClassOn);
                r.find("iframe").hide().removeClass(t.tabClassOn);
                r.find("#iframe" + u.find("table").attr("id")).show().addClass(t.tabClassOn);
                t.currentEvent(u.find(".inner").attr("data-value"))
            }
        }), n.url && (f = $('<iframe class="LRADMS_iframe" id="iframe' + n.id + '" height="100%" width="100%" src="' + n.url + '" frameBorder="0"><\/iframe>'), r.append(f), f.load(function () {
            window.setTimeout(function () {
                learun.loading({
                    isShow: !1
                })
            },
            200)
        })), n.closed ? u.find("td:eq(2)").find("div").click(function () {
            var t = i.find("li").length;
            a(n);
            i.find("li:eq(" + (t - 2) + ")").find("table td:eq(1)").trigger("click")
        }).hover(function () {
            u.hasClass(t.tabClassOn) || $(this).removeClass().addClass(t.tabClassClose)
        },
        function () {
            u.hasClass(t.tabClassOn) || $(this).addClass(t.tabClassClose + "_noselected")
        }) : u.find("td:eq(2)").html(""), i.find("li:eq(" + (i.find("li").length - 1) + ")").find("table td:eq(1)").trigger("click"), t.addEvent(n)) : (i.find("li").removeClass("on").addClass("off"), i.find("#" + n.id).parent().removeClass("off").addClass("on"), r.find("iframe").hide().removeClass("on"), r.find("#iframe" + n.id).show().addClass("on"))
    }
    function y(n) {
        var r, o;
        if ($(".tab ul>li").length >= 10) return dialogAlert("为保证系统效率,只允许同时运行10个功能窗口,请关闭一些窗口后重试！", 0),
        !1;
        n.moduleIdCookie == !0 ? (top.$.cookie("currentmoduleId", n.id, {
            path: "/"
        }), n.dataValue = n.id) : n.dataValue = top.$.cookie("currentmoduleId");
        h(n);
        r = $(".tab ul").width() - 4;
        r > t.width && (t.tabScroll || (t.tabScroll = !0, f = $('<div class="' + t.tabClassScrollLeft + '"><i><\/i><\/div>').click(function () {
            u(f, !0)
        }), e = $('<div class="' + t.tabClassScrollRight + '"><i><\/i><\/div>').click(function () {
            u(e, !1)
        }), cW -= t.tabScrollWidth * 2, s.width(cW), f.insertBefore(s), e.insertBefore(s)), o = t.width - r, i.animate({
            left: o - 43
        }), displaylicount = i.find("li").length)
    }
    var t = {
        items: [],
        width: 500,
        height: 500,
        tabcontentWidth: 498,
        tabWidth: 100,
        tabHeight: 32,
        tabScroll: !0,
        tabScrollWidth: 19,
        tabClass: "tab",
        tabContentClass: "tab-div-content",
        tabClassOn: "on",
        tabClassOff: "off",
        tabClassClose: "tab_close",
        tabClassInner: "inner",
        tabClassInnerLeft: "innerLeft",
        tabClassInnerMiddle: "innerMiddle",
        tabClassInnerRight: "innerRight",
        tabClassText: "text",
        tabClassScrollLeft: "scroll-left",
        tabClassScrollRight: "scroll-right",
        tabClassDiv: "tab-div",
        addEvent: null,
        currentEvent: null
    },
    o = 0,
    c,
    u,
    f,
    e;
    $.extend(t, n);
    c = t.tabWidth * t.items.length;
    t.tabScroll ? c -= t.tabScrollWidth * 2 : null;
    var i = $("<div />").attr("id", "jquery_tab_div").height(t.tabHeight).addClass(t.tabClass).append("<ul />"),
    r = $("<div />").attr("id", "jquery_tab_div_content").width(t.tabcontentWidth).height(t.height - t.tabHeight).addClass(t.tabContentClass),
    w = t.items.length * t.tabWidth - t.width,
    l = "";
    l = '<table class="' + t.tabClassInner + '"  id="{0}" data-value="{3}" border="0" cellpadding="0" cellspacing="0"><tr><td class="' + t.tabClassInnerLeft + '"><\/td><td class="' + t.tabClassInnerMiddle + '"><span class="' + t.tabClassText + '"><i class="fa {2}"><\/i>&nbsp;{1}<\/span><\/td><td class="' + t.tabClassInnerMiddle + '"><div class="' + t.tabClassClose + " " + t.tabClassClose + '_noselected"><\/div><\/td><td class="' + t.tabClassInnerRight + '"><\/td><\/tr><\/table>';
    u = function (n, r) {
        var f = Number(i.css("left").replace("px", "")),
        e,
        s;
        f ? null : f = 0;
        var u = 0;
        if (!r || f != 0) {
            if (r) o--,
            u = f + i.find("li").eq(o).width(),
            u > 0 ? u = 0 : null;
            else {
                if (e = $(".tab ul").width() - parseInt(i.offset().left) * -1 - t.tabcontentWidth - 82, s = i.find("li").eq(o).width(), e > 0) e < s && (s = e);
                else return;
                u = f - s;
                o++
            }
            u == 0 ? i.animate({
                left: parseInt(-19)
            }) : i.animate({
                left: parseInt(u)
            })
        }
    };
    $.each(t.items,
    function (n, t) {
        h(t)
    });
    t.tabScroll && (f = $('<div class="' + t.tabClassScrollLeft + '"><i><\/i><\/div>').click(function () {
        u($(this), !0)
    }), e = $('<div class="' + t.tabClassScrollRight + '"><i><\/i><\/div>').click(function () {
        u($(this), !1)
    }), t.width -= t.tabScrollWidth * 2);
    var v = $("<div />").css({
        position: "relative",
        width: t.width,
        height: t.tabHeight
    }).append(f).append(e).addClass(t.tabClassDiv),
    s = $("<div />").css({
        width: t.width,
        height: t.tabHeight,
        float: "left"
    }).append(i),
    p = $(this).append("").append(v.append(s)).append(r);
    return $(window).resize(function () {
        t.width = $(window).width() - 100;
        t.height = $(window).height() - 56;
        t.tabcontentWidth = $(window).width() - 80;
        v.width(t.width);
        r.width(t.tabcontentWidth).height(t.height - t.tabHeight)
    }),
    i.find("li:first td:eq(1)").click(),
    p.extend({
        addTab: h,
        newTab: y
    })
};
var tablist;
loadnav = function () {
    function u(n) {
        var i = '<div class="sub-nav-wrap">',
        r;
        return i += '<ul class="sub-nav">',
        r = learun.data.get(["authorizeMenu"]),
        $.each(r,
        function (r, u) {
            u.ParentId == n && (e(u.ModuleId) == 0 ? i += "<li><a id=" + u.ModuleId + '><i class="fa ' + u.Icon + '"><\/i>' + u.FullName + "<\/a><\/li>" : (i += '<li class="sub" title=' + (u.Description == null ? "" : u.Description) + "><a id=" + u.ModuleId + '><i class="fa ' + u.Icon + '"><\/i>' + u.FullName + "<\/a>", i += f(u.ModuleId), i += "<\/li>"), t[u.ModuleId] = u)
        }),
        i += "<\/ul>",
        i += "<\/div>"
    }
    function f(n) {
        var i = '<div class="sub-child"><ul>',
        r = learun.data.get(["authorizeMenu"]);
        return $.each(r,
        function (r, u) {
            u.ParentId == n && (i += "<li title=" + (u.Description == null ? "" : u.Description) + "><a id=" + u.ModuleId + '><i class="fa ' + u.Icon + '"><\/i>' + u.FullName + "<\/a><\/li>", t[u.ModuleId] = u)
        }),
        i += "<\/ul><\/div>"
    }
    function e(n) {
        var t = 0,
        i = learun.data.get(["authorizeMenu"]);
        return $.each(i,
        function (i, r) {
            if (r.ParentId == n) return t++,
            !1
        }),
        t
    }
    var t = {};
    tablist = $("#tab_list_add").Tab({
        items: [{
            id: "desktop",
            title: "欢迎首页",
            closed: !1,
            icon: "fa fa fa-desktop",
            url: contentPath + "/Home/AdminDefaultDesktop"
        },
        ],
        tabScroll: !1,
        width: $(window).width() - 100,
        height: $(window).height() - 56,
        tabcontentWidth: $(window).width() - 80,
        addEvent: function (n) {
            n.closed && n.isNoLog != !0 && $.ajax({
                url: contentPath + "/Home/VisitModule",
                data: {
                    moduleId: n.id,
                    moduleName: n.title,
                    moduleUrl: n.url
                },
                type: "post",
                dataType: "text"
            })
        },
        currentEvent: function (n) {
            top.$.cookie("currentmoduleId", n, {
                path: "/"
            })
        }
    });
    $("#GoToHome").click(function () {
        tablist.newTab({
            id: "desktop",
            title: "欢迎首页",
            closed: !1,
            icon: "fa fa fa-desktop",
            url: contentPath + "/Home/AdminDefaultDesktop"
        })
    });
    $("#UserSetting").click(function () {
        tablist.newTab({
            id: "UserSetting",
            title: "个人中心",
            closed: !0,
            icon: "fa fa fa-user",
            url: contentPath + "/PersonCenter/Index"
        })
    });
    var n = "",
    i = 0,
    r = learun.data.get(["authorizeMenu"]);
    $.each(r,
    function (r, f) {
        f.ParentId == "0" && (i++, n += '<li class="item">', n += "    <a id=" + f.ModuleId + '  href="javascript:void(0);" class="main-nav">', n += '        <div class="main-nav-icon"><i class="fa ' + f.Icon + '"><\/i><\/div>', n += '        <div class="main-nav-text">' + f.FullName + "<\/div>", n += '        <span class="arrow"><\/span>', n += "    <\/a>", n += u(f.ModuleId), n += "<\/li>", t[f.ModuleId] = f)
    });
    $("#nav").append(n);
    $("#nav li a").click(function () {
        var i = $(this).attr("id"),
        n = t[i];
        n.Target == "iframe" && tablist.newTab({
            moduleIdCookie: !0,
            id: i,
            title: n.FullName,
            closed: !0,
            icon: n.Icon,
            url: contentPath + n.UrlAddress
        })
    });
    $("#nav li.item").hover(function () {
        var n, t, i, r;
        $("#navDiv").width(4e3);
        n = $(this).find(".sub-nav-wrap");
        t = n.find(".sub-nav").find("li").length;
        t > 0 && (n.css("bottom", "initial"), $(this).addClass("on"), n.show(), i = n.offset().top + n.height(), r = $(window).height(), i > r && n.css("bottom", "0px"))
    },
    function () {
        $("#navDiv").width(80);
        $(this).removeClass("on");
        $(this).find(".sub-nav-wrap").hide()
    });
    $("#nav li.sub").hover(function () {
        var n = $(this).find("ul");
        n.show();
        var i = $(this).find("ul").offset().top,
        t = n.height(),
        r = $(window).height();
        i + t > r ? n.css("top", parseInt("-" + (t - 11))).css("left", "130px") : n.css("top", "0px").css("left", "130px")
    },
    function () {
        $(this).find("ul").hide();
        $(this).find("ul").css("top", "0px")
    });
    $(window).resize(function (n) {
        window.setTimeout(function () {
            $("#navDiv").height($(window).height())
        },
        200);
        n.stopPropagation()
    });
    $("#navDiv").height($(window).height())
};
$.removeTab = function (n) {
    function i(n) {
        var i = t.find("li").length;
        t.find("#" + n).parents("li").remove();
        u.find("#iframe" + n).remove();
        t.find("li:eq(" + (i - 2) + ")").find("table td:eq(1)").trigger("click")
    }
    var r = tabiframeId().replace("iframe", ""),
    t = $(".tab-div"),
    u = $(".tab-div-content");
    switch (n) {
        case "reloadCurrent":
            $.currentIframe().learun.reload();
            break;
        case "closeCurrent":
            i(r);
            break;
        case "closeAll":
            t.find("div.tab_close").each(function () {
                var n = $(this).parents(".inner").attr("id");
                i(n)
            });
            break;
        case "closeOther":
            t.find("div.tab_close").each(function () {
                var n = $(this).parents(".inner").attr("id");
                r != n && i(n)
            })
    }
};
$(function () {
    learun.init({
        callBack: function () {
            loadnav()
        },
        themeType: "1"
    })
})