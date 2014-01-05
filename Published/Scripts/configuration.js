function displayConfig(configId)
{
    if ($('#configurationDisplay').visible)
    {
        $('#configurationDisplay').slideUp("fast");
    }

    $.ajax({
        url: getConfigUrl,
        data: { configurationId: configId }
    }).done(function (response) {
        if (response.length > 0) {
            displayConfigurationJSON(response);
        }
    });
}

function displayConfigurationJSON(configuration)
{
    var configValues = configuration.split(','),
        property;

    for (var i = 0; i < configValues.length; i++)
    {
        property = configValues[i].split(':');

        switch (i)
        {
            case 0:
                $('#configurationDisplay #configId').val(property[1]);
            case 1:
                $('#name').html(property[1].replace(/"/g,''));
                break;
            case 2:
                $('#atmosphericVisibility').html(property[1].replace(/"/g,''));
                break;
            case 3:
                $('#userDistance').html(property[1].replace(/"/g,''));
                break;
            case 4:
                $('#closingSpeed').html(property[1].replace(/"/g,''));
                break;
            case 5:
                $('#initialTarget').html(property[1].replace(/"/g,''));
                break;
            case 6:
                $('#realTarget').html(property[1].replace(/"/g,''));
                break;
            case 7:
                if (property[1] === 'true') {
                    $('#movingTargets').prop('checked', true);
                }
                else {
                    $('#movingTargets').prop('checked', false);
                }
                break;
            case 8:
                if (property[1] === 'true') {
                    $('#active').prop('checked', true);
                }
                else
                {
                    $('#active').prop('checked', false);
                }
                break;
            case 9:
                break;
            case 10:
                $('#background').html(property[1].replace(/"/g, ''));
            case 11:
                $('#target').html(property[1].replace(/"/g, '').replace(/}/g, ''));
            default:
                continue;
        }
    }    

    $('#configurationInputs').slideUp('fast', function ()
    {
        $('#configurationDisplay').slideDown();
    });
}

function editConfigurationJSON(configuration) {
    var configValues = configuration.split(','),
        property;

    for (var i = 0; i < configValues.length; i++) {
        property = configValues[i].split(':');

        switch (i) {
            case 0:
                $('#Configuration_Id').val(property[1]);
            case 1:
                $('#Configuration_Name').val(property[1].replace(/"/g, ''));
                break;
            case 2:
                $('#Configuration_AtmosphericVisibility').val(property[1].replace(/"/g, ''));
                break;
            case 3:
                $('#Configuration_UserDistance').val(property[1].replace(/"/g, ''));
                break;
            case 4:
                $('#Configuration_ClosingSpeed').val(property[1].replace(/"/g, ''));
                break;
            case 5:
                $('#Configuration_InitialTargetSize').val(property[1].replace(/"/g, ''));
                break;
            case 6:
                $('#Configuration_RealTargetSize').val(property[1].replace(/"/g, ''));
                break;
            case 7:
                if (property[1] === 'true') {
                    $('#Configuration_MovingTargets').prop('checked', true);
                }
                else {
                    $('#Configuration_MovingTargets').prop('checked', false);
                }
                break;
            case 9:
                break;
            case 10:
                $('#Configuration_BackgroundColour').val(property[1].replace(/"/g, ''));
            case 11:
                $('#Configuration_TargetColour').val(property[1].replace(/"/g, '').replace(/}/g, ''));
            default:
                continue;
        }
    }

    $('#configurationDisplay').slideUp('fast', function () {
        $('#configurationInputs').slideDown();
    });
}

function activateConfig()
{
    var configId = $('#configurationDisplay #configId').val();

    $.ajax({
        url: activateConfigUrl,
        type: 'POST',
        data: { configurationId: configId }
    }).done(function (response) {
        displayConfig(configId);
    });
}

function deleteConfig()
{
    var configId = $('#configurationDisplay #configId').val();

    $.ajax({
        url: deleteConfigUrl,
        type: 'POST',
        data: { configurationId: configId }
    }).done(function (response) {
        location.reload();
    });
}

function editConfig()
{
    var configId = $('#configurationDisplay #configId').val();


    $.ajax({
        url: getConfigUrl,
        data: { configurationId: configId }
    }).done(function (response) {
        editConfigurationJSON(response);
    })
}

function saveConfig()
{
    $('#configurationInputs').submit();
}

function cancelNewConfig()
{
    $('#configurationInputs input').each(function () {
        if ($(this).attr('type') === 'text')
        {
            $(this).val('');
        }
        else if ($(this).attr('type') === 'hidden') {
            $(this).val('');
        }
        else if ($(this).attr('type') === 'checkbox')
        {
            $(this).prop('checked', false);
        }
    });

    $('#configurationInputs').slideUp('fast');
}

function newConfigurationHandler()
{
    $('#createConfiguration').click(function()
    {
        $('#configurationInputs input[type="hidden"]').each(function () {
            $(this).val('');
        });

        $('#configurationInputs input[type="text"]').each(function ()
        {
            $(this).val('');
        });

        $('#configurationInputs input[type="checkbox"]').each(function () {
            $(this).prop('checked', false);
        });

        $('#configurationDisplay').slideUp('fast', function () {
            $('#configurationInputs').slideDown('fast');
        });
    });
}

function setSelectChangeHandler()
{
    $('#configSelect').change(function () {

        var configId = $(this).val();

        if (configId)
        {
            displayConfig(configId);

            $('body').on('click', '#configurationDisplay #edit', editConfig);
            $('body').on('click', '#configurationDisplay #activate', activateConfig);
            $('body').on('click', '#configurationDisplay #delete', deleteConfig);

            $('#configurationInputs').slideUp('fast', function()
            {
                $('#configurationDisplay').slideDown('fast');
            });
        }
    });
}

function checkFormValues()
{
    $('#configurationInputs input').each(function ()
    {
        if ($(this).attr('type') === 'text' && $(this).val() !== '')
        {
            $('#configurationInputs').slideDown('fast');
            return;
        }
    });
}

$(document).ready(function ()
{
    $('#configurationDisplay').hide();
    $('#configurationInputs').hide();

    setSelectChangeHandler();
    newConfigurationHandler();

    checkFormValues();

    $('body').on('click', '#save', saveConfig);
    $('body').on('click', '#cancel', cancelNewConfig);

});