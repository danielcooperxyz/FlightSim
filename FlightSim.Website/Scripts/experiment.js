//-----------------------------------------------------------------------
// <copyright file="flightSim.js" owner="Daniel Cooper">
// Copyright (c) Daniel Cooper. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

var target, startTime, timer, diameterValues, animationTimes, opacityValues, staticAnimation = 2000;

// Generate a random value for the x position of the target
function getRandomX() {
	var randomInt = Math.random(),
	winWidth = winObj.width();

	return Math.floor(randomInt * winWidth);
}

// Generate a random value for the y position of the target
function getRandomY(){
	var randomInt = Math.random(),
	winHeight = winObj.height();

	return Math.floor(randomInt * winHeight);
}

// Set the position of the target
function setPosition(target)
{
	var newCircle,
	randX = getRandomX(),
	randY = getRandomY();

	$('#Experiment_XPosition').val(randX);
	$('#Experiment_YPosition').val(randY);

	target.css('top', randY);
	target.css('left', randX);
}

// Parse data for target dimensions and opacity
function parseTargetData()
{
    var radiuses = $('#Experiment_Radiuses').val(),
        opacities = $('#Experiment_Opacities').val(),
        temp;

    radiusKeyVals = radiuses.split("],");
    diameterValues = new Array();
    animationTimes = new Array();

    for (var i = 0; i < radiusKeyVals.length; i++) {
        temp = radiusKeyVals[i].substring(1, radiusKeyVals[i].length).split(",");

        diameterValues[i] = parseFloat(temp[0]) * 2;
        animationTimes[i] = parseInt(temp[1]) * 1000;
    }

    opacityValues = new Array();
    opacities = opacities.split(",");

    for (var i = 0; i < opacities.length; i++) {
        opacityValues[i] = parseFloat(opacities[i]);
    }
}

// Set up initial position
function setupTarget()
{
    var initialSize = parseFloat($('#initialTargetSize')),
        movingTargets = $('#movingTargets').val();
    target = $('#template');

    if (movingTargets === 'True') {
        target.css('height', initialSize);
        target.css('width', initialSize);
        target.css('opacity', 0);
        target.removeAttr('hidden');
        setPosition(target);


        for (var i = 0; i < diameterValues.length; i++) {
            if (i == 0) {
                $('#Experiment_StartTime').val(new Date().getTime());
            }

            target = target.animate(
                {
                    width: diameterValues[i].toString() + "px",
                    height: diameterValues[i].toString() + "px",
                    opacity: opacityValues[i].toString()
                },
                animationTimes[i],
                'linear');
        }
    }
    else
    {
        target.css('height', '4px');
        target.css('width', '4px');
        target.css('opacity', 0);
        target.removeAttr('hidden');
        setPosition(target);
        target.animate({ opacity: '1' }, staticAnimation);
    }

    $('#Experiment_StartTime').val(new Date().getTime());
}

// Save experiment results
function postResults()
{
    $('#Experiment_EndTime').val(new Date().getTime());

    var stoppedTarget = target.stop();

    $('#Experiment_EndDiameter').val(stoppedTarget.css('height'));
    $('#Experiment_EndOpacity').val(stoppedTarget.css('opacity'));

    $('#experimentResults').submit();
}

// Display target on save page
function displayTarget()
{
    target = $('#template');

    var xPosition = $('#Experiment_XPosition').val(),
    yPosition = $('#Experiment_YPosition').val(),
    diameter = $('#Experiment_EndDiameter').val(),
    opacity = $('#Experiment_EndOpacity').val();

    target.removeAttr('hidden');
    target.css('left', parseInt(xPosition));
    target.css('top', parseInt(yPosition));
    target.css('height', diameter);
    target.css('width', diameter);
    target.css('opacity', opacity);
    target.show();

    reactionTime = $('#Experiment_ReactionTime').val();

    reactionTime = reactionTime / 1000;

    $('#reactionTime').html(reactionTime + ' seconds');
}

$(document).ready(function()
{
	// Remove body margin
    var body = $('body').css('margin', 0),
	object = $('');

	winObj = $(window);

	if ($("#homePage").length > 0)
	{
	    //$("#startButton").click(function ()
	    //{
	    //    window.open(experimentUrl, "popUpWindow", "width:600, height: 400, toolbar:no");
	    //});
	}
	
	if ($("#experiment").length)
	{
	    winObj.click(postResults);
	    parseTargetData();

        // Begin
	    setupTarget();
	}

	if ($('#saveExperiment').length)
	{
	    displayTarget();
	}
});