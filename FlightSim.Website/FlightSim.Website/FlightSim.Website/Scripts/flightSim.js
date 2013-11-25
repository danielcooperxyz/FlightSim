var winObj, transConstant, sizeConstant, target, timer;

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

function updateTransparency()
{
    var transValue = getNewValue(timer, transparency);

    target.css("opacity", value);
}

function updateSize()
{
    var sizeValue = getNewValue(timer, size);

    target.height(size);
    target.width(size);
}

function updateObject()
{
    timer++;

    updateTransparency();
    updateSize();
}

$(document).ready(function()
{
	// Remove body margin
	var body = $('body').css('margin', 0),
	object = $('')

	winObj = $(window);
	
    // Set timer
	if ($("#experiment").length)
	{
	    transparency = $('#TransparencyConstant');
	    size = $('#SizeConstant');
	    target = $("#template");

	    setPosition(target);
	    target.show();

	    timer = 0;

	    setPosition(target);

	    setInterval(updateObject, 1000);
	}
});
