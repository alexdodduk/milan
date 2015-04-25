$(document).ready(function () {
    bindEnterKitItemDropDownList();
    bindCKEditor();
    bindMenuButton();
    showMenuButton();
    resizeYouTubeVideos();
});

function bindEnterKitItemDropDownList() {
    var $lstCategories = $('#lstCategories');

    if ($lstCategories.length) {
        $lstCategories.change(function () {
            $.post($lstCategories.data("action"), { selection: $lstCategories.val() }, function (data) {
                var $lstSubCategories = $('#lstSubCategories'),
                    arrayLength = data.length;

                // add each subcategory object to the dropdownlist and show it (if there are any subcategories)
                if (arrayLength) {

                    $lstSubCategories.children("option").remove();

                    // add a ---Select--- option
                    $lstSubCategories.append($("<option></option>").attr("value", "").text("---Select---"));

                    // add all items to the dropdownlist
                    for (var i = 0; i < arrayLength; i++) {
                        var subcategory = data[i];

                        $lstSubCategories.append($("<option></option>").attr("value", subcategory.ID).text(subcategory.Name));
                    }

                    // enable the dropdownlist
                    $lstSubCategories.attr("disabled", false);
                }
                    // otherwise clear the items and disable the subcategories dropdownlist
                else {
                    $lstSubCategories.children("option").remove();
                    $lstSubCategories.append($("<option></option>").attr("value", "").text("---Select---"));
                    $lstSubCategories.attr("disabled", true);
                }
            });
        });
    }
}

function bindCKEditor() {
    if ($('#txtBody').length) {
        CKEDITOR.replace('txtBody');
    }
}

function bindMenuButton() {
    $('button#nav, #overlay').click(function () {
        var $container = $('#container');

        $container.removeClass("nav-bump");
        $container.toggleClass("nav-open");
    });

    $('button#nav').hover(function (e) {
        var $container = $('#container');

        if ($container.hasClass("nav-open")) {
            return;
        }

        $container.addClass("nav-bump");
    });

    $('#overlay').hover(function (e) {
        var $container = $('#container');
        $container.removeClass("nav-bump");
    });
}

function showMenuButton() {
    $('#nav').css("left", "20px");
}

function resizeYouTubeVideos() {
    $('iframe').each(function () {
        $(this).removeAttr("width").removeAttr("height");
    });
}