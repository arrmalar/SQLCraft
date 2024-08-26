$('#statusMessage').css({
    'display': 'block',
    'color': '#fff',
    'background-color': 'red',
    'padding': '10px',
    'border-radius': '5px',
    'text-align': 'center'
});

async function generateByAI(attempt = 1) {
    var formData = $('form').serialize();

    try {
        const url = '@Url.Action("GenerateByAI", "Query", new { area = "Admin" })';
        console.log("Generated URL:", url);

        const response = await $.ajax({
            url: url,
            type: 'POST',
            data: formData
        });

        if (response.success) {
            $('#statusMessage').hide();

            $('textarea[name="QueryRiddle.Question"]').val(response.question);
            $('textarea[name="QueryRiddle.CorrectAnswer"]').val(response.correctAnswer);
        } else {
            $('#statusMessage').show().html(response.message);

            if (response.status === 429 && attempt < 5) {
                let delay = Math.pow(2, attempt) * 1000;
                $('#statusMessage').html(response.message + ` Retrying in ${delay / 1000} seconds...`);
                await new Promise(resolve => setTimeout(resolve, delay));
                return generateByAI(attempt + 1);
            } else {
                throw new Error(response.message || "Unknown error occurred.");
            }
        }
    } catch (error) {
        console.error("An error occurred: " + error.status);
        $('#statusMessage').show().html("An error occurred: " + error.status);
    }
}