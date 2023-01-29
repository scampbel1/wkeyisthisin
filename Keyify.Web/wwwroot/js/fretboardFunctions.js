function UpdateModel(url, scale, addNote, selectedNotes) {

    var dataPost = { previouslySelectedNotes: selectedNotes, newlySelectedNote: addNote, selectedScale: scale };

    $.ajax({
        url: url,
        async: 'true',
        type: "POST",
        data: dataPost,
        datatype: "json",
        success: function (data) {
            $("#Fretboard").html(data);
        }
    });
}

function ChangeInstrument(url, scale, selectedNotes) {

    var dataPost = { previouslySelectedNotes: selectedNotes, selectedScale: scale };

    $.ajax({
        url: url,
        async: 'true',
        type: "POST",
        data: dataPost,
        datatype: "json",
        success: function (data) {
            $("#Fretboard").html(data);
        }
    });
}