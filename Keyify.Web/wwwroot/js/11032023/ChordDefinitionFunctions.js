function SubmitChordDefinition() {
    ValidateFields(document);
}

function ValidateFields(document) {
    var nameField = {
        htmlFieldName: "chordDefintionName",
        fullName: "Chord Definition Name",
        validateField: validateField,
        document: document
    };

    var nameValidation = nameField.validateField();
}

function validateField() {

    var fieldName = this.htmlFieldName;
    var fullName = this.fullName;

    //This is resulting in null - is this something to do with the document reference ("this" refers to where the current function was called from)
    var fieldName = document.getElementById(fieldName).value;

    console.log(`${fullName} - '${fieldName}'`);

    if (fieldName == undefined || fieldName == null || fieldName == '') {
        const message = `Warning '${fieldName}' is not a valid value for ${fullName}.`;

        console.warn(message);
        alert(message);

        return false;
    }

    return true;
}