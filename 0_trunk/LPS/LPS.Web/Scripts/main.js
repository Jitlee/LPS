// JScript 文件
var offSetHeight = 0;
$(document).ready(function(){
            var dom = $(this);
            var h = document.documentElement.clientHeight;
            var page = $("#page");
            var pageOffSetHeight = $("#pageOffSetHeight");
            if(pageOffSetHeight.length > 0) {
                offSetHeight = Number($("#pageOffSetHeight").text());
            }
            if(page.length > 0) {
                var parent = page.offsetParent();
                var w = parent.width() - 18;
                page.height(h - 65 - offSetHeight);
                page.width(w);
                if($.browser.msie && $.browser.version == "6.0") {
                    var pageBody = $("#pageBody");
                    if(pageBody.length > 0) {
                        if(page.height() < pageBody.height()) {
                            pageBody.width(w - 18 - (pageBody.innerWidth() - pageBody.width()));
                        }
                    }
                }
            }
            
             /*$('.gridview_skin tr:even:not(:first)').addClass('old');*/
		    var gridview_skin = $('.gridview_skin tr:not(:first)');
	        gridview_skin.hover(
		        function() {$(this).addClass('highlight');},
		        function() {$(this).removeClass('highlight'); }
	        );

	        var gridview_skin_first_cb = $('.gridview_skin tr:first').find('input[type="checkbox"]');
	        var gridview_skin_first_tb = $('.gridview_skin tr:first').find('input[type="text"]');
	        if(gridview_skin_first_cb.length > 0) {
	            var n = gridview_skin.length;
	            var i = 0;
	            gridview_skin.click(
		            function() {
		                var p = $(this);
			            if (p.hasClass('selected')) {
				            p.removeClass('selected');
				            p.find('input[type="checkbox"]').removeAttr('checked');
				            i--;
			            } else {
				            p.addClass('selected');
				            p.find('input[type="checkbox"]').attr('checked','checked');
				            i++;
			            }
			            if(i == n) {
			                gridview_skin_first_cb.attr('checked','checked');
			            } else {
			                gridview_skin_first_cb.removeAttr('checked');
			            } 
		            }
	            );
	            gridview_skin_first_cb.click(
	            function () {
	                var p = $(this);
	                if(p.attr('checked') == false) {
				        gridview_skin.removeClass('selected');
				        gridview_skin.find('input[type="checkbox"]').removeAttr('checked');
				        i = 0;
	                } else {
				        gridview_skin.addClass('selected');
				        gridview_skin.find('input[type="checkbox"]').attr('checked','checked');
				        i = n;
	                }
	            });
	        } else if(gridview_skin_first_tb.length > 0) {
	           gridview_skin_first_tb.hide();
	           gridview_skin.click(function(){
	                var checkValue = new Array();
                    var p = $(this);
		            p.siblings().removeClass('selected');
		            p.addClass('selected');
		            p.find('input[type="radio"]').attr('checked','checked');
		            $.each(p.find('.checkValue'),function(e) { checkValue.push($(this).text()) });
		            gridview_skin_first_tb.val(checkValue);
	            });
	            gridview_skin.dblclick(chooseRow);
	            
	             $("#btnChoose").click(chooseRow);
	            function chooseRow () {
	                var p = gridview_skin.filter(".selected");
	                if(p.length == 1) {
	                    var checkValue = new Array();
	                    $.each(p.find('.checkValue'),function(e) { checkValue.push($(this).text()) });
	                    $.close(checkValue);  
	                }
	            }
	        }
        });
//        function selectItemDblclick()
//        {
//            var gridview_skin = $('.gridview_skin tr:not(:first)');
//            var p = gridview_skin;
//            var checkValue = new Array();
//            $.each(p.find('.checkValue'),function(e) { checkValue.push($(this).text()) });
//            $.close(checkValue);
//        }
        
        
$(window).resize(function(){
    var h = document.documentElement.clientHeight;
    var page = $("#page");
    if(page.length > 0) {
        var parent = page.offsetParent();
        page.height(h - 65 - offSetHeight);
        w = parent.width() - 18;
        page.width(w);
        if($.browser.msie && $.browser.version == "6.0") {
            var pageBody = $("#pageBody");
            if(pageBody.length > 0) {
                if(page.height() < pageBody.height()) {
                    pageBody.width(w - 18 - (pageBody.innerWidth() - pageBody.width()));
                }
            }
        }
    }
});

