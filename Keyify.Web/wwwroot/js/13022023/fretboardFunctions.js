//TODO: Should this be async?
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


async function copyContent(quickLinkCode) {
    try {
        var quickLinkUrl = document.location.protocol + "//" + document.location.host + "/ql/v1/" + quickLinkCode;

        await navigator.clipboard.writeText(quickLinkUrl);

        console.log('Quick Link copied to clipboard');
    } catch (err) {
        console.error('Failed to copy Quick Link: ', err);
    }
}

function ToggleLockSelection(url, scale, selectedNotes, lockSelection) {

    var dataPost = { selectedNotes: selectedNotes, selectedScale: scale, lockSelection: lockSelection };

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