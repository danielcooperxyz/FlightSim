function setSelectChangeHandler()
{
    $('#configSelect').change(function () {

        var configId = $(this).val();

        $.ajax({
            url: getConfigUrl,
            data: { configurationId: configId }
        }).done(function (response)
        {
            if (response.length > 0)
            {
                var config = response.split(',');


            }
        });
    });
}

$(document).ready(function ()
{
    setSelectChangeHandler();
});