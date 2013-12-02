var winObj, transConstant, sizeConstant, target, timer, initialRadius, realTargetSize, userDist, atmosVis, closingSpeed, diameter;


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

function getRadius(time)
{
    // Radius = (b * x_0/(R - (v *t)))

    return ((realTargetSize * userDist) / (atmosVis - (closingSpeed * time)));
}

function getOpacity(newRadius)
{
    // TRANSPARENCY =1-(e^(-2.996 * (r_0 / r)))

    return 1-Math.exp(-2.996 * (initialRadius / newRadius));
}

function setPosition(target)
{
	var newCircle,
	randX = getRandomX(),
	randY = getRandomY();

	target.css('top', randY);
	target.css('left', randX);
}

function updateTransparency(newRadius)
{
    var opacity = getOpacity(newRadius);

    target.css("opacity", 1 * opacity);
}

function updateSize()
{
    var radius = getRadius(timer),
        sizeValue = (radius * 200);

    target.height(sizeValue);
    target.width(sizeValue);

    return radius;
}

function updateObject()
{
    timer++;

    var newRadius = updateSize();

    if (target.css("opacity") < 1) {
        updateTransparency(newRadius);
    }
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
	    timer = 0;
	    target = $("#template");
	    realTargetSize = parseInt($("#RealTargetSize").val());
	    userDist = parseInt($("#UserDistance").val());
	    atmosVis = parseInt($("#AtmosphericVisibility").val());
	    initialRadius = parseInt($("#InitialRadius").val());
	    closingSpeed = parseInt($("#ClosingSpeed").val());
	    diameter = initialRadius * 2;

        // Setup initial target
	    target.css("height", diameter);
	    target.css("width", diameter);
	    setPosition(target);
	    target.show();

	    setPosition(target);

	    setInterval(updateObject, 1000);
	}
});
