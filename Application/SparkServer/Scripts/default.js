$(function () {

	// Mobile menu toggle
	$(".mobile-menu-toggle").on("click", function () {
		var menu = $("nav ul");
		if (menu.is(":visible")) {
			menu.slideUp(250);
		} else {
			menu.slideDown(250);
		}
	});

	// Smooth scrolling
	$(".nav-link").click(function(event){		
		event.preventDefault();
		$('html,body').animate({ scrollTop:$(this.hash).offset().top - 60 }, 400);
	});
	
	// ScrollTo Plugin
	$(window).scroll(function () {
        if ($(window).scrollTop() <= "200") {
            $("#toTop").hide();
        }
        if ($(window).scrollTop() > "200") {
            $("#toTop").show();
        }
    });

});