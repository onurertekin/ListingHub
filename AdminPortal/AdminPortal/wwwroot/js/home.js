$(document).ready(function () {
    getCategory();

});

function getCategory() {
    $.ajax({
        url: portalApiEndpoint + '/listing-api/categories?parentCategoryId=-1',
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            $("#category-list").empty(); // Listeyi temizle
            response.categories.forEach(function (category) {
                var imageUrl = getCategoryImage(category.id);
                var categoryItem = `<a class="category" category-id="${category.id}" href="#"><img src="${imageUrl}" class="category-image">${category.name}</a><div class="sub-categories" category-id="${category.id}"></div>`;
                $("#category-list").append(categoryItem);

                // Eğer alt kategoriler varsa, onları yükle
                getSubcategories(category.id);
            });
        },
        error: function (xhr, status, error) {
            alert("Hata Oluştu!");
        }
    });
}

function getSubcategories(parentId) {
    $.ajax({
        url: portalApiEndpoint + '/listing-api/categories?parentCategoryId=' + parentId,
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        success: function (response) {

            response.categories.forEach(function (subcategory) {
                var categoryItem = `<a class="sub-category" category-id="${subcategory.id}" href="#">${subcategory.name}</a>`;
                $(`#category-list .sub-categories[category-id=${parentId}]`).append(categoryItem);
            });
        },
        error: function (xhr, status, error) {
            alert("Hata Oluştu!");
        }
    });
}

// Kategori ID'sine göre sabit resim URL'sini döndüren fonksiyon
function getCategoryImage(categoryId) {
    // Kategori ID'lerine göre resim URL'lerini belirle
    var imageMap = {
        1: '/images/araba.png',
        2: '/images/emlak.jpg',
    };

    // Eğer kategori için bir resim tanımlanmamışsa, varsayılan bir resim döndür
    return imageMap[categoryId];
}
