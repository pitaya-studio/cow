﻿(function ($) {
    $.fn.menu = function (options) {
        var menuList = [
            { ID: "Home", PID: "", Name: "首页", Url: "Home/Index", target: "_self" },
            { ID: "Task", PID: "", Name: "任务", Url: "Task/Index/List", target: "_self" },
            { ID: "Breed", PID: "", Name: "繁殖", Url: "Breed/Index/Index", target: "_self" },
            { ID: "Breed-Home", PID: "Breed", Name: "繁殖首页", Url: "Breed/Index/Index", target: "_self" },
            { ID: "Breed-Insemination", PID: "Breed", Name: "发情配种", Url: "Task/Index/TaskInsemination", target: "_self" },
            { ID: "Breed-Calf", PID: "Breed", Name: "产犊", Url: "Breed/Calf/Add", target: "_self" },
            { ID: "Breed-Forbid", PID: "Breed", Name: "禁配", Url: "Breed/ForbidInsemination/Edit", target: "_self" },
            { ID: "Breed-UnForbid", PID: "Breed", Name: "解禁", Url: "Breed/UnForbidInsemination/Edit", target: "_self" },
            { ID: "Feed", PID: "", Name: "饲养", Url: "Feed/Index/Index", target: "_self" },
            { ID: "Feed-Home", PID: "Feed", Name: "饲养首页", Url: "Feed/Index/Index", target: "_self" },
            { ID: "Feed-CowGroup", PID: "Feed", Name: "牛群维护", Url: "Feed/CowGroup/List", target: "_self" },
            { ID: "Feed-CowHouse", PID: "Feed", Name: "牛舍维护", Url: "Feed/CowHouse/List", target: "_self" },
            { ID: "Feed-GroupRemind", PID: "Feed", Name: "分群提示", Url: "Feed/CowGroup/Remind", target: "_self" },
            { ID: "Feed-Fodder", PID: "Feed", Name: "饲料维护", Url: "Feed/Fodder/Maintain", target: "_blank" },
            { ID: "Feed-Grade", PID: "Feed", Name: "体况评分", Url: "Feed/Grade/Add", target: "_self" },
            { ID: "Feed-Formua", PID: "Feed", Name: "饲料加工", Url: "Feed/Fodder/Calculate", target: "_blank" },
            { ID: "Feed-Empty", PID: "Feed", Name: "空槽记录", Url: "Feed/Empty/Add", target: "_self" },
            { ID: "Feed-Remain", PID: "Feed", Name: "剩料记录", Url: "Feed/Remain/Add", target: "_self" },
            { ID: "Milk", PID: "", Name: "奶厅", Url: "Milk/Index/Index", target: "_self" },
            { ID: "Milk-Home", PID: "Milk", Name: "奶厅首页", Url: "Milk/Index/Index", target: "_self" },
            { ID: "Milk-Parameter", PID: "Milk", Name: "奶厅参数", Url: "Milk/Parameter/Edit", target: "_self" },
            { ID: "Milk-DailyMilkYield", PID: "Milk", Name: "日产奶量", Url: "Milk/DailyMilkYield/Add", target: "_self" },
            { ID: "Milk-Check", PID: "Milk", Name: "奶量抽查", Url: "Milk/MilkabilityCheck/Add", target: "_blank" },
            { ID: "Medical", PID: "", Name: "兽医", Url: "Medical/Index/Index", target: "_self" },
            { ID: "Medical-Home", PID: "Medical", Name: "兽医首页", Url: "Medical/Index/Index", target: "_self" },
            { ID: "Medical-Diagnoses", PID: "Medical", Name: "疾病诊治", Url: "Medical/Diagnoses/Add", target: "_self" },
            { ID: "Medical-AdjustGroup", PID: "Medical", Name: "康复调群", Url: "Medical/Adjust/Index", target: "_self" },
            { ID: "Medical-Mastitis", PID: "Medical", Name: "隐乳检测", Url: "Medical/Mastitis/Add", target: "_self" },
            { ID: "Medical-RepairHoof", PID: "Medical", Name: "修蹄", Url: "Medical/RepairHoof/Add", target: "_self" },
            { ID: "Medical-RemoveAddMilk", PID: "Medical", Name: "去附乳", Url: "Medical/RemoveAddMilk/Add", target: "_self" },
            { ID: "Platform", PID: "", Name: "平台", Url: "Platform/Farm/List", target: "_self" },
            { ID: "Platform-Farm", PID: "Platform", Name: "牧场管理", Url: "Platform/Farm/List", target: "_self" },
            { ID: "Platform-Formula", PID: "Platform", Name: "配方管理", Url: "Platform/Formula/List", target: "_self" },
            { ID: "Platform-FormulaAssign", PID: "Platform", Name: "指定配方", Url: "Platform/Formula/Assign", target: "_self" },
            { ID: "Platform-Fodder", PID: "Platform", Name: "饲料管理", Url: "Platform/Fodder/List", target: "_self" },
            { ID: "FarmAdmin", PID: "", Name: "场长", Url: "Users/Index/List", target: "_self" },
            { ID: "FarmAdmin-User", PID: "FarmAdmin", Name: "用户管理", Url: "Users/Index/List", target: "_self" },
            { ID: "FarmAdmin-GroupAssign", PID: "FarmAdmin", Name: "牛群分配", Url: "Feed/CowGroup/Assign", target: "_self" },
            { ID: "FarmAdmin-TaskAdjust", PID: "FarmAdmin", Name: "任务调整", Url: "Task/Index/Adjust", target: "_self" },
            { ID: "FarmAdmin-InGroup", PID: "FarmAdmin", Name: "入群", Url: "FarmAdmin/InGroup/List", target: "_self" },
            { ID: "FarmAdmin-OutGroup", PID: "FarmAdmin", Name: "离群", Url: "FarmAdmin/OutGroup/List", target: "_self" }
        ];

        //默认值
        var defaultVal = {
            mainMenuSelectedID: 'Home',
            subMenuSelectedID: ''
        };

        var $args = arguments;

        var host = window.location.host;

        return this.each(function () {

            // Public methods
            // Usage: $('.tree').tree2014('expand', el);
            var methods = {
                example: function () {
                }
            }

            //Check for methods
            if (typeof options === 'string') {
                if ($.isFunction(methods[options])) {
                    // do some check and prepare
                    // apply传入的this对象很重要，在public method中通过this引用
                    methods[options].apply(this, Array.prototype.slice.call($args, 1));
                    //http://stackoverflow.com/questions/1986896/what-is-the-difference-between-call-and-apply
                }
                return;
            }

            // Initialize
            var opt = $.extend(defaultVal, options);

            var $elem = $(this);

            var rendMenu = function () {
                $elem.html('');
                var header = $('<div class="mt10 mb10"></div>').appendTo($elem);
                var logo = $('<div class="btn-group">                                             \
                        <img src="http://' + host + '/Images/emutong_logo.png" style="width:164px; height:33px;" />   \
                    </div>'
                    ).appendTo(header);
                var mainMenuContainer = $('<div class="btn-group"></div>').appendTo(header);
                var mainMenuUL = $('<ul class="nav nav-pills"></ul>').appendTo(mainMenuContainer);
                var subMenuContainer = $('<div class="btn-group subMenuContainer" style="margin: 10px 0px 10px 45px;"></div>').appendTo($elem);
                $.each(menuList, function () {
                    if (this.PID == '') {
                        var menuItemLi = $('<li></li>').appendTo(mainMenuUL);
                        var menuItemA = $('<a href="http://' + host + '/' + this.Url + '" target="' + this.target + '">' + this.Name + '</a>').appendTo(menuItemLi);
                        if (opt.mainMenuSelectedID == this.ID) {
                            menuItemLi.addClass('active');
                            menuItemA.attr('href', 'javascript:void(0);').attr('target', '');
                        }
                    }
                    else if (this.PID == opt.mainMenuSelectedID) {
                        var subMenuItem = $('<button type="button" class="btn btn-default submenu" href="http://' + host + '/' + this.Url + '">' + this.Name + '</button>').appendTo(subMenuContainer);
                        if (opt.subMenuSelectedID == this.ID) {
                            subMenuItem.removeClass('btn-default').addClass('btn-primary');
                        }
                    }
                });
            }

            var bindEvent = function () {
                $('.subMenuContainer .btn-default').click(function () { window.open($(this).attr('href')); });
            }

            rendMenu(opt.data);
            bindEvent();
        });
    }

    if (!String.prototype.format) {
        String.prototype.format = function () {
            var args = arguments;
            return this.replace(/{(\d+)}/g, function (match, number) {
                return typeof args[number] != 'undefined' ? args[number] : match;
            });
        };
    }

})(jQuery);