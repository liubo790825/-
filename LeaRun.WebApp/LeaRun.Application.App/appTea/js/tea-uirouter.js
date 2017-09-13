//学习：http://blog.csdn.net/xyphf/article/details/67686538

angular.module('starter.uirouter', [])





.config(function ($stateProvider, $urlRouterProvider) {
    // Ionic uses AngularUI Router which uses the concept of states
    // Learn more here: https://github.com/angular-ui/ui-router
    // Set up the various states which the app can be in.
    // Each state's controller can be found in controllers.js
    $stateProvider
    // setup an abstract state for the tabs directive
    .state('tab', {
        url: '/tab',
        abstract: true,
        templateUrl: 'templates/tabs.html',
        controller: 'lrTabsCtrl'
    })
    // Each tab has its own nav history stack:
    // 主页
    .state('tab.home', {
        url: '/home',
        views: {
            'tab-home': {
                templateUrl: 'templates/tab-home.html',
                controller: 'HomeCtrl'
            }
        }
    })
    // 实例
    .state('tab.cases', {
        url: '/cases',
        views: {
            'tab-cases': {
                templateUrl: 'templates/tab-cases.html',
                controller: 'CasesCtrl'
            }
        }
    })
    // 通知(已读未读)
    .state('tab.notice', {
        url: '/notice',
        views: {
            'tab-notice': {
                templateUrl: 'templates/tab-notice.html',
                controller: 'NoticeCtrl'
            }
        }
    })
    //公告
    .state('tab.announce', {
        url: '/home/:announceId',
        views: {
            'tab-announce': {
                templateUrl: 'templates/tab-home.html',
                controller: 'AnnounceCtrl'
            }
        }
    })
    // 我的
    .state('tab.personCenter', {
        url: '/personCenter',
        views: {
            'tab-personCenter': {
                templateUrl: 'templates/tab-personCenter.html',
                controller: 'PersonCenterCtrl'
            }
        }
    })

    ////新生报到
    //.state('tab.baodao', {
    //    url: '/baodao',
    //    views: {
    //        'tab-baodao': {
    //            templateUrl: 'templates/tab-baodao.html',
    //            controller: 'BaodaoCtrl'
    //        }
    //    }
    //})

        //报表？？
        //.state("reports",
        //        { url: "/reports", templateUrl: "templates/tab-baobiao.html" })
            .state("reports.baobiao1",
                { url: "/baobiao1", templateUrl: "templates/homeApps/reports/Xsbdqkfx.html" })
            .state("reports.baobiao2",
                { url: "/baobiao2", templateUrl: "templates/homeApps/reports/Xsbdqkfx.html" })







    //登录页
    .state('login', {
        url: '/login',
        templateUrl: 'templates/login.html',
        controller:'LoginCtrl'
    });












    // if none of the above states are matched, use this as the fallback
    $urlRouterProvider.otherwise('/login');
})


    //.config(function ($stateProvider, $urlRouterProvider) {
    //    $urlRouterProvider.when("", "/reports");
    //    $stateProvider
    //        .state("reports",
    //            { url: "/reports", templateUrl: "templates/tab-baobiao.html" })
    //        .state("reports.baobiao1",
    //            { url: "/baobiao1", templateUrl: "templates/homeApps/reports/Xsbdqkfx.html" })
    //        .state("reports.baobiao2",
    //            { url: "/baobiao2", templateUrl: "templates/homeApps/reports/Xsbdqkfx.html" })

    //})
;



