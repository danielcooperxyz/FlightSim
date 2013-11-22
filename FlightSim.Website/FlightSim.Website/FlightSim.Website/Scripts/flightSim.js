var winObj, transparency, size, target;

function getRandomX(){
	var randomInt = Math.random(),
	winWidth = winObj.width();

	return Math.floor(randomInt * winWidth);
}

function getRandomY(){
	var randomInt = Math.random(),
	winHeight = winObj.height();

	return Math.floor(randomInt * winHeight);
}

function getNewValue(time, constant){
	return (time * constant);
}

function setPosition(target)
{
	var newCircle,
	randX = getRandomX(),
	randY = getRandomY();

	target.css('top', randY);
	target.css('left', randX);
}

function updateObject()
{
    
    setPosition(target);
}

$(document).ready(function()
{
	// Remove body margin
	var body = $('body').css('margin', 0),
	object = $('')

	winObj = $(window);
	transparency = $('#transparencyConstant');
	size = $('#sizeConstant');

	
    // Set timer
	if ($("#experiment").length)
	{
	    target = $("#template");

	    setPosition(target);
	    target.show();

	    setInterval(updateObject, 1000);
	}
});