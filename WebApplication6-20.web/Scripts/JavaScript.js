$(function () {
    console.log("hello");
    $(".isChasidush").on('change', function () {
        if($(".isChasidush").prop('checked')) {
            $(".type").prop('disabled', 'disabled');
        }
        else
        {
         $(".type").removeAttr('disabled');
        }
    });
});