var winObj, transparency, size;

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

function setPosition(object){
	var newCircle,
	randX = getRandX(),
	randY = getRandY();

	object.css('top', randY);
	object.css('left', randX);
}

function updateObject(object){

	
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
	setInterval(updateObject(object), 100);
});