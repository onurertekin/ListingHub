$(document).ready(function () {

    getListing();
});


function getListing() {
    $.ajax({
        url: portalApiEndpoint + '/listing-api/listings?pageSize=10',
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            $("#listings").empty(); // Listeyi temizle

            response.listings.forEach(function (listing) {
                // API'den gelen photo değerini tam bir URL'ye dönüştürün
                //var photoUrl = listing.photo ? `/images/listings/${listing.id}/${listing.photo}.png` : '/images/listings/default.png';
                var photoUrl = listing.photo ? `https://listing-images-aws.s3.eu-north-1.amazonaws.com/${listing.photo}` : 'https://listing-images-aws.s3.eu-north-1.amazonaws.com/default.png';

                var fieldTypeName = listing.fieldTypeName.toLowerCase();

                var listingItem =
                    `<div class="listing">
                         <div class="img" style="background-image: url('${photoUrl}');"></div>
                         <a href="/${fieldTypeName}/listings/${listing.id}" class="title">${listing.title}</a>
                     </div>`;
                $("#listings").append(listingItem);
            });
        },
        error: function (xhr, status, error) {
            alert("Hata Oluştu!");
        }
    });
}
