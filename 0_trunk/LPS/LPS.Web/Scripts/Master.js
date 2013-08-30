var offSetHeight = 0;
var offSetWidth = 175 + 6;
$(document).ready(function () {
    var w = document.documentElement.clientWidth;
    var page = $("#page");
    var pageOffSetHeight = $("#pageOffSetHeight");
    if (pageOffSetHeight.length > 0) {
        offSetHeight = Number($("#pageOffSetHeight").text());
    }
    if (page.length > 0) {
        var parent = page.offsetParent();
        var h = parent.height() - 60 - offSetHeight;
        page.height(h);
        w = w - offSetWidth - 16;
        page.width(w);
        if ($.browser.msie && $.browser.version) {
            var pageBody = $("#pageBody");
            if (pageBody.length > 0) {
                if (page.height() < pageBody.height()) {
                    pageBody.width(w - 18 - (pageBody.innerWidth() - pageBody.width()));
                }
            }
        }
    }
    setInterval("clock()", 1000);

    //var oMenu1 = $("#" + getCookie("menu1"));
    var currentId = $.cookie("menu");
    if (currentId != "") {
        var oMenu2 = $("#" + currentId);
        if (oMenu2.length > 0) {
            oMenu2.addClass("current2");
            var oMenu1 = oMenu2.parent();
            oMenu1.show();
            oMenu1.prev().addClass("current1s");
        }
    }

    // $("#menu1 ul").hide();
    $("#menu1 div").each(function (i) {
        $(this).click(function () {
            var p = $(this);
            if (!p.hasClass("current1")) {
                $(".current1").removeClass("current1").next().slideUp("fast");
                p.addClass("current1");
            }
            p.next().slideToggle("fast");

        }).next().children().each(function (j) {
            $(this).click(function () {
                var p = $(this);
                $.cookie("menu", p.attr("id"), { path: '/' });
                $(".current2").removeClass("current2");
                $(this).addClass("current2");
            });
        });
    });



    /*$('.gridview_skin tr:even:not(:first)').addClass('old');*/
    var gridview_skin = $('.gridview_skin tr:not(:first)');

    gridview_skin.hover(
		        function () { $(this).addClass('highlight'); },
		        function () { $(this).removeClass('highlight'); }
	        );

    var gridview_skin_first_cb = $('.gridview_skin tr:first').find('input[type="checkbox"]');
    var gridview_skin_first_tb = $('.gridview_skin tr:first').find('input[type="text"]');
    if (gridview_skin_first_cb.length > 0) {
        var n = gridview_skin.length;
        var i = 0;
        gridview_skin.click(
		            function () {
		                var p = $(this);
		                if (p.hasClass('selected')) {
		                    p.removeClass('selected');
		                    p.find('input[type="checkbox"]').removeAttr('checked');
		                    i--;
		                } else {
		                    p.addClass('selected');
		                    p.find('input[type="checkbox"]').attr('checked', 'checked');
		                    i++;
		                }
		                if (i == n) {
		                    gridview_skin_first_cb.attr('checked', 'checked');
		                } else {
		                    gridview_skin_first_cb.removeAttr('checked');
		                }
		            }
	            );
        gridview_skin_first_cb.click(
	            function () {
	                var p = $(this);
	                if (p.attr('checked') == false) {
	                    gridview_skin.removeClass('selected');
	                    gridview_skin.find('input[type="checkbox"]').removeAttr('checked');
	                    i = 0;
	                } else {
	                    gridview_skin.addClass('selected');
	                    gridview_skin.find('input[type="checkbox"]').attr('checked', 'checked');
	                    i = n;
	                }
	            });
    } else if (gridview_skin_first_tb.length > 0) {
        gridview_skin_first_tb.hide();
        gridview_skin.click(function () {
            var p = $(this);
            p.siblings().removeClass('selected');
            p.addClass('selected');
            p.find('input[type="radio"]').attr('checked', 'checked');
            gridview_skin_first_tb.val(p.find('.ID').text());
        });
        gridview_skin.dblclick(function () {
            var p = $(this);
            $.close(p.find('.ID').text());
        });
    }

});

$(window).resize(function () {
    var w = document.documentElement.clientWidth;
    var page = $("#page");
    if (page.length > 0) {
        var parent = page.offsetParent();
        var h = parent.height() - 60 - offSetHeight;
        w = w - offSetWidth - 16;
        page.height(h);
        page.width(w);
        if ($.browser.msie && $.browser.version) {
            var pageBody = $("#pageBody");
            if (pageBody.length > 0) {
                if (page.height() < pageBody.height()) {
                    pageBody.width(w - 18 - (pageBody.innerWidth() - pageBody.width()));
                }
            }
        }
    }

});

function clock() {
    var time = new Date().toLocaleString() + ' 星期' + '日一二三四五六'.charAt(new Date().getDay());
    var oTime = document.getElementById("spanTime");
    if (navigator.appName.indexOf("Explorer") > -1) {
        oTime.innerText = time;
    }
    else {
        oTime.textContent = time;
    }
    return time;
}