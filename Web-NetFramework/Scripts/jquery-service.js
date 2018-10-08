/**
 * This JavaScript Library is for requesting the common JSON result.
 * 
 * 
 * 
 * 
 * 
 * 
 * */
; (function () {
    if (window.$ == undefined) {
        console.error("please add the jquery first");
    }

    /**
     * 发送邮件
     * @param {any} toAddress
     */
    var _sendMail = function (toAddress) {
        if (!toAddress) {
            alert("Please add an Email Address");
            return;
        }
        var data = {};
        $.ajax({
            url: '/Email/SendAsync',
            data: {
                 toAddress
            }
        }).then(data => {
            console.log(data);
            _showData(data);
            return data;
        })
    }
    /**
     * 我的邮件
     * */
    var _myMail = function () {
        $.ajax({
            url: '/Email/MeAsync',
        }).then(data => {
            console.log(data);
            _showData(data);
            return data;
        })
    }
    /**
     * 所有用户
     * @param show If false, it will not show the result in the element with '.info' class
     * */
    var _users = function () {
        var show = true;
        $.ajax({
            url: '/User/UsersAsync',
        }).then(data => {
            console.log(data);
            _showData(data);
            return data;
        })
    }
    /**
     * 我的信息
     * */
    var _meInfo = function () {
        $.ajax({
            url: '/User/MeAsync',
        }).then(data => {
            console.log(data);
            _showData(data);
            return data;
        })
    }
    /**
     * 我的照片
     * */
    var _mePhoto = function () {
        $.ajax({
            url: '/Photo/MeAsync',
        }).then(data => {
            console.log(data);
            _showData(data);
            return data;
        })
    }
    /**
     * 列出计划
     * */
    var _listPlan = function () {
        $.ajax({
            url: '/Plan/PlansAsync',
        }).then(data => {
            console.log(data);
            _showData(data);
            return data;
        })
    }
    /**
     * 获得特定日历的事件
     * */
    var _events = function () {
        $.ajax({
            url: '/Calendar/EventsAsync',
        }).then(data => {
            console.log(data);
            _showData(data);
            return data;
        })
    }
    /**
     * 获得特定日历
     * */
    var _calendar = function () {
        $.ajax({
            url: '/Calendar/CalendarAsync',
        }).then(data => {
            console.log(data);
            _showData(data);
            return data;
        })
    }


    /**
     * 显示数据
     * @param {any} data
     */
    var _showData = function (data) {
        if ($('.info')) {
            $('.info').text(JSON.stringify(data,2));
        }
    }
    var _ajaxHelper = {
        sendMail: _sendMail,
        myMail:_myMail,
        users: _users,
        myInfo: _meInfo,
        myPhoto: _mePhoto,
        listPlan: _listPlan,
        events: _events,
        calendar:_calendar
    };


    if (!window.ajaxHelper) {
        window.ajaxHelper = { };
    }
    Object.assign(window.ajaxHelper, _ajaxHelper);
})();