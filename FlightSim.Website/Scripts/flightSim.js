var winObj, transConstant, sizeConstant, target, timer, initialRadius, realTargetSize, userDist, atmosVis, closingSpeed, diameter, intervalId;


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

    return 1 * (1 - Math.exp(-2.996 * (initialRadius / newRadius)));
}

function setPosition(target)
{
	var newCircle,
	randX = getRandomX(),
	randY = getRandomY();

	$('#x-position').val(randX);
	$('#y-position').val(randY);

	target.css('top', randY);
	target.css('left', randX);
}

function updateObject()
{
    timer++;

    if (intervalId > 0) {
        clearInterval(intervalId);
    }

    var newRadius = getRadius(timer),
        sizeValue = newRadius * 200,
        newOpacity = parseFloat(target.css('opacity')),
        radiusLog = $('#radiusLog').val(),
        opacityLog = $('#opacityLog').val(),
        timeLog = $('#timeLog').val();


    if (newRadius > 0) {
                
        if (target.css("opacity") < 1) {
           
            newOpacity = 1 - getOpacity(newRadius);
        }

        $('#radiusLog').val(radiusLog + "," + newRadius);
        $('#opacityLog').val(opacityLog + "," + newOpacity);
        $('#timeLog').val(timeLog + "," + timer);
        
        target.animate({ width: sizeValue, height: sizeValue, opacity: newOpacity }, 1000, updateObject);
    }   
    else
    {
        target.animate({ width: 500, height: 500 }, 1000);
    }
}

$(document).ready(function()
{
	// Remove body margin
	var body = $('body').css('margin', 0),
	object = $('')

	winObj = $(window);

	
    //Set timer
	if ($("#experiment").length)
	{
	    //window.open("http://mantis/Flightsim/", "popUpWindow", "width:600, height: 600, toolbar:no");
	
	    var start = new Date().getTime(),
        elapsed = '0.0',
        timer = window.setInterval(function () {
	        var time = new Date().getTime() - start;

	        elapsed = Math.floor(time / 100) / 10;
	        if (Math.round(elapsed) == elapsed) { elapsed += '.0'; }

	        document.title = elapsed;

	    }, 100);

	    timer = 0;
	    target = $("#template");
        realTargetSize = parseInt($("#RealTargetSize").val());
	    userDist = parseInt($("#UserDistance").val());
	    atmosVis = parseInt($("#AtmosphericVisibility").val());
	    initialRadius = 0.002;
	    closingSpeed = parseInt($("#ClosingSpeed").val());
	    diameter = initialRadius * 2;
	    intervalId = 0;

        // Setup initial target
	    target.css("height", 0.1);
	    target.css("width", 0.1);
	    target.css("opacity", 0);
	    setPosition(target);
	    target.show();

	    setPosition(target);

	    updateObject();
	}
});
