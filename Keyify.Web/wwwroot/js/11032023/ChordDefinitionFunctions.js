const chordDefinitionNameFullName = "Chord Definition Name";
const chordDefinitionNameFieldName = "chordDefinitionName";

function SubmitChordDefinition() {

    ValidateFields();
}

function ValidateFields() {

    //Example of Implicit Binding -see: "You Don't Know JS - this & Object Prototypes" - Page 14
    var nameTextbox = {
        htmlFieldName: chordDefinitionNameFieldName,
        fullName: chordDefinitionNameFullName,
        validate: validateTextbox
    };

    var nameValidation = nameTextbox.validate();

    if (nameValidation) {
        alert('Success!');
    }
}

function validateTextbox() {

    let fullName = this.fullName;
    let fieldValue = document.getElementById(this.htmlFieldName).value;

    console.log(`${fullName} - '${fieldValue}'`);

    if (fieldValue == undefined || fieldValue == null || fieldValue == '') {
        const message = `Warning '${fieldValue}' is not a valid value for ${fullName}.`;

        console.warn(message);
        alert(message);

        return false;
    }
    else {
        //TODO: Search for existing Chord Template name

        //If name exists return false
    }

    return true;
}