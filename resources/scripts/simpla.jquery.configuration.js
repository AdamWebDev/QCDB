function pageLoad(sender, args) {

    // Content box tabs:
    $('.content-box .content-box-content div.tab-content').hide(); // Hide the content divs

    // managing hashes and showing/hiding content
    if (document.location.hash != '') {
        var tabname = window.location.hash;
        $('ul.content-box-tabs li a[href=' + tabname + ']').addClass('current'); // Add the class "current" to the default tab
        $(tabname).addClass('current').show();
    }
    else {
        $('ul.content-box-tabs li a.default-tab').addClass('current'); // Add the class "current" to the default tab
        $('.content-box-content div.default-tab').show(); // Show the div with class "default-tab"
    }

    // actions for switching tabs!
    $('.content-box ul.content-box-tabs li a').click(function () { // When a tab is clicked...
		$(this).parent().siblings().find("a").removeClass('current'); // Remove "current" class from all tabs
		$(this).addClass('current'); // Add class "current" to clicked tab
		var currentTab = $(this).attr('href'); // Set variable "currentTab" to the value of href of clicked tab
		$(currentTab).siblings().hide(); // Hide all content divs
		$(currentTab).show(); // Show the content div with the id equal to the id of clicked tab
		window.location.hash = $(this).attr('href');
		return false;
	});

    //Close button:
    $(".close").click(function () {
		$(this).parent().fadeTo(400, 0, function () { // Links with the class "close" will close parent
			$(this).slideUp(400);
		});
		return false;
	});

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



    /* Insurance Policies page...
    *******************************************************************/

    // when form is initally loaded, show certain fields based on the populated data
    if ($('.ddTypeOfPolicy option:selected').text() == "CGL") 
        $('.CGLDetails').removeClass("hidden");
    
    if ($('.ddPolicyLimit option:selected').text() == "Other")
        $('.txtPolicyLimitOther').removeClass("hidden");

    if ($('.ddBroker').prop("selectedIndex") > 0)
        $('.newBrokerEmailLink').removeClass("hidden");


    // show CGL options when a user changes the policy type dropdown
    $('.ddTypeOfPolicy').change(function () {
        if ($('.ddTypeOfPolicy option:selected').text() == "CGL") {
            $('.CGLDetails').removeClass("hidden");
        } else {
            $('.CGLDetails').hideAndClear();
        }
    });

    // when the user selects a policy limit of "Other", show the additional field
    $('.ddPolicyLimit').change(function () {
        if ($('.ddPolicyLimit option:selected').text() == "Other")
            $('.txtPolicyLimitOther').removeClass("hidden");
        else
            $('.txtPolicyLimitOther').val('').addClass("hidden");
    });

    $('.ddBroker').change(function () {

    });

    // when adding a new insurance company, show and populate!
    $('.newInsuranceCompanyLink').click(function () {
        if ($(this).hasClass("show")) { //hide it!
            $('.newIns, .addInsButton').addClass("hidden");
            $(this).html("Add New");
            $('.editInsuranceButton').removeClass("hidden");
        } else { // show it!
            $('.newIns input[type="text"]').val('');
            $('.newIns, .addInsButton').removeClass("hidden");
            $(this).html("Cancel");
            $('.editInsuranceButton').addClass("hidden");
        }
        $(this).toggleClass("show");
    });

    // when editing an insurance company, show and populate!
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
            var insCompName = $('.ddInsuranceCompanies option:selected').text();
            var insCompEmail = $('.txtInsEmail').val();
            $('#txtNewInsuranceCompanyName').val(insCompName);
            $('#txtNewInsComEmail').val(insCompEmail);
            $('.newInsuranceCompanyLink').addClass("hidden");
        }
        $(this).toggleClass("show");
    });

    // when adding a new broker, show and populate!
    $('.newBrokerLink').click(function () {
        if ($(this).hasClass("show")) { // if it's showing, hide it!
            $('.newBroker, .addBrokerButton').addClass("hidden");
            $(this).html("Add New");
            $('.editBrokerButton').removeClass("hidden");
        } else { // show it!
            $('.newBroker input[type="text"]').val('');
            $('.newBroker, .addBrokerButton').removeClass("hidden");
            $(this).html("Cancel");
            $('.editBrokerButton').addClass("hidden");
        }
        $(this).toggleClass("show");
    });

    $('.editBrokerButton').click(function () {
        if ($(this).hasClass("show")) { // if it's showing, hide it!
            $('.newBroker, .addBrokerButton').addClass("hidden");
            $('.newBroker input[type="text"]').val('');
            $(this).html("Edit");
            $('.editBrokerButton').removeClass("hidden");
        } else { // show it!
            var BrokerName = $('.ddBroker option:selected').text();
            $('.newBroker input[type="text"]').val(BrokerName);
            $('.newBroker, .saveBrokerButton').removeClass("hidden");
            $(this).html("Cancel");
            $('.newBrokerLink').addClass("hidden");
        }
        $(this).toggleClass("show");

    });

    // when adding a new broker, show and populate!
    $('.newBrokerEmailLink').click(function () {
        if ($(this).hasClass("show")) { // if it's showing, hide it!
            $('.newBrokerEmail, .addBrokerEmailButton').addClass("hidden");
            $(this).html("Add New");
            $('.editBrokerEmailButton').removeClass("hidden");
        } else { // show it!
            $('.newBrokerEmail input[type="text"]').val('');
            $('.newBrokerEmail, .addBrokerEmailButton').removeClass("hidden");
            $(this).html("Cancel");
            $('.editBrokerEmailButton').addClass("hidden");
        }
        $(this).toggleClass("show");
    });

    $('.editBrokerEmailButton').click(function () {
        if ($(this).hasClass("show")) {
            $('.newBrokerEmail, .saveBrokerEmailButton').addClass("hidden");
            $(this).html("Edit");
            $('.newBrokerEmailLink').removeClass("hidden");
            $('.newBrokerEmail input[type="text"]').val('');
        } else {
            var BrokerEmail = $('.ddBrokerEmail option:selected').text();
            $('.newBrokerEmail input[type="text"]').val(BrokerEmail);
            $('.newBrokerEmail, .saveBrokerEmailButton').removeClass("hidden");
            $(this).html("Cancel");
            $('.newBrokerEmailLink').addClass("hidden");
        }
        $(this).toggleClass("show");
    });

    /* End of insurance policy scripts...
    *********************************************************************/
   

} // end of page load


function ResetScrollPosition() {
    setTimeout("window.scrollTo(0,0)", 0);
}

jQuery.fn.hideAndClear = function () {
    this.addClass("hidden");
    this.find('select').val('');
    this.find('input[type="text"]').val('');
} 
  
  