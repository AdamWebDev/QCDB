//$(document).ready(function () {
function pageLoad(sender, args) {

    // Content box tabs:

    $('.content-box .content-box-content div.tab-content').hide(); // Hide the content divs

    if (document.location.hash != '') {
        var tabname = window.location.hash;
        $('ul.content-box-tabs li a[href=' + tabname + ']').addClass('current'); // Add the class "current" to the default tab
        $(tabname).addClass('current').show();
    }
    else {
        $('ul.content-box-tabs li a.default-tab').addClass('current'); // Add the class "current" to the default tab
        $('.content-box-content div.default-tab').show(); // Show the div with class "default-tab"
    }

    $('.content-box ul.content-box-tabs li a').click( // When a tab is clicked...
			function () {
			    $(this).parent().siblings().find("a").removeClass('current'); // Remove "current" class from all tabs
			    $(this).addClass('current'); // Add class "current" to clicked tab
			    var currentTab = $(this).attr('href'); // Set variable "currentTab" to the value of href of clicked tab
			    $(currentTab).siblings().hide(); // Hide all content divs
			    $(currentTab).show(); // Show the content div with the id equal to the id of clicked tab
			    window.location.hash = $(this).attr('href');
			    return false;
			}
		);

    //Close button:

    $(".close").click(
			function () {
			    $(this).parent().fadeTo(400, 0, function () { // Links with the class "close" will close parent
			        $(this).slideUp(400);
			    });
			    return false;
			}
		);

    // Alternating table rows:

    $('tbody tr:even').addClass("alt-row"); // Add class "alt-row" to even table rows

    // Check all checkboxes when the one in a table head is checked:

    $('.check-all').click(
			function () {
			    $(this).parent().parent().parent().parent().find("input[type='checkbox']").attr('checked', $(this).is(':checked'));
			}
		);

    // Initialise Fancybox Modal window:

    $('.fancybox').fancybox({
        autoSize: false,
        width: '80%'
    }); // Applies modal window to any link with attribute rel="modal"



    // Insurance Policies page...

    if ($('.ddTypeOfPolicy option:selected').text() == "CGL") {
        $('.CGLDetails').removeClass("hidden");
    }

    $('.ddTypeOfPolicy').change(function () {
        if ($('.ddTypeOfPolicy option:selected').text() == "CGL") {
            $('.CGLDetails').removeClass("hidden");
        } else {
            $('.CGLDetails').hideAndClear();
        }
    });



    $('.ddPolicyLimit').change(function () {
        if ($('.ddPolicyLimit option:selected').text() == "Other")
            $('.txtPolicyLimitOther').removeClass("hidden");
        else
            $('.txtPolicyLimitOther').val('').addClass("hidden");
    });


    $('.newInsuranceCompanyLink').click(function () {
        if ($(this).hasClass("show")) { //hide it!
            $('.newIns, .addButton').addClass("hidden");
            $(this).html("Add New");
            $('.editInsuranceButton').removeClass("hidden");
        } else { // show it!
            $('.newIns input[type="text"]').val('');
            $('.newIns, .addButton').removeClass("hidden");
            $(this).html("Cancel");
            $('.editInsuranceButton').addClass("hidden");
        }
        $(this).toggleClass("show");
    });

    $('.editInsuranceButton').click(function () {
        if ($(this).hasClass("show")) { // hide it!
            $('.newIns').addClass("hidden");
            $(this).html("Edit");
            $('.editButton').addClass("hidden");
            $('#hdnInsName, #hdnInsEmail').val('');
            $('.newInsuranceCompanyLink').removeClass("hidden");
        } else { // show it!
            $('.newIns').removeClass("hidden");
            $(this).html("Cancel");
            $('.editButton').removeClass("hidden");
            $('#txtNewInsuranceCompanyName').val($('#hdnInsName').val());
            $('#txtNewInsComEmail').val($('#hdnInsEmail').val());
            $('.newInsuranceCompanyLink').addClass("hidden");
        }
        $(this).toggleClass("show");
    });

    // end of insurance policies scripts

}


function ResetScrollPosition() {
    setTimeout("window.scrollTo(0,0)", 0);
}

jQuery.fn.hideAndClear = function () {
    this.addClass("hidden");
    this.find('select').val('');
    this.find('input[type="text"]').val('');
} 
  
  