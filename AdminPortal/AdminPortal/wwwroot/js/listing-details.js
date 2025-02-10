$(document).ready(function () {
    getListingDetails();
});

function getListingDetails() {
    $.ajax({
        url: portalApiEndpoint + '/listing-api/listings/' + listingId + '?includeDescription=true&includeFields=true',
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            $("#title").text(response.title);
            $("#price").text(response.price);
            $("#listingDate").text(response.listingDate);

            getAllFields();
        },
        error: function (xhr, status, error) {
            alert("Hata Oluştu!");
        }
    });
}

function getAllFields() {
    $.ajax({
        url: portalApiEndpoint + "/listing-api/fields?fieldType=" + fieldType,
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            console.log(response);
            $(response.fields).each(function (i, field) {
                $("table#fields").append('<tr field-id="' + field.id + '"><td class="key">' + field.fieldName + '</td><td class="value"></td></tr>');
            });

            getFieldValues();
        },
        error: function (xhr, status, error) {
            alert("Hata Oluştu!");
        }
    });
}

function getFieldValues() {
    $.ajax({
        url: portalApiEndpoint + '/listing-api/listings/' + listingId + "/fields",
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        success: function (response) {

            $(response.listingFields).each(function (i, listingField) {
                debugger;
                $("table#fields tr[field-id=" + listingField.fieldId + "] .value").html(listingField.value);
            });
        },
        error: function (xhr, status, error) {
            alert("Hata Oluştu!");
        }
    });
}