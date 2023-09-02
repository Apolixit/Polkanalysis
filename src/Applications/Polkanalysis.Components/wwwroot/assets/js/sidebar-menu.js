$(function() {
    "use strict";


$.sidebarMenu = function(menu) {
	const animationSpeed = 300,
		subMenuSelector = '.sidebar-submenu';
	$(menu).on('click', 'li a', function(e) {
		let $this = $(this);
		let checkElement = $this.next();
		if (checkElement.is(subMenuSelector) && checkElement.is(':visible')) {
			checkElement.slideUp(animationSpeed, function() {
				checkElement.removeClass('menu-open');
			});
			checkElement.parent("li").removeClass("active");
		}
		//If the menu is not visible
		else if ((checkElement.is(subMenuSelector)) && (!checkElement.is(':visible'))) {
			//Get the parent menu
			let parent = $this.parents('ul').first();
			//Close all open menus within the parent
			let ul = parent.find('ul:visible').slideUp(animationSpeed);
			//Remove the menu-open class from the parent
			ul.removeClass('menu-open');
			//Get the parent li
			let parent_li = $this.parent("li");
			//Open the target menu and add the menu-open class
			checkElement.slideDown(animationSpeed, function() {
				//Add the class active to the parent li
				checkElement.addClass('menu-open');
				parent.find('li.active').removeClass('active');
				parent_li.addClass('active');
			});
		}
		//if this isn't a link, prevent the page from being redirected
		if (checkElement.is(subMenuSelector)) {
			e.preventDefault();
		}
	});
}



});