// Write your JavaScript code.

//Script for Payment
var $form = $('#payment-form');
$form.on('submit', payWithStripe);

/* If you're using Stripe for payments */
//function payWithStripe(e) {
//    e.preventDefault();

//    /* Visual feedback */
//    $form.find('[type=submit]').html('Validating <i class="fa fa-spinner fa-pulse"></i>');

//    var PublishableKey = 'pk_test_b1qXXwATmiaA1VDJ1mOVVO1p'; // Replace with your API publishable key
//    Stripe.setPublishableKey(PublishableKey);

//    /* Create token */
//    var expiry = $form.find('[name=cardExpiry]').payment('cardExpiryVal');
//    var ccData = {
//        number: $form.find('[name=cardNumber]').val().replace(/\s/g, ''),
//        cvc: $form.find('[name=cardCVC]').val(),
//        exp_month: expiry.month,
//        exp_year: expiry.year
//    };

//    Stripe.card.createToken(ccData, function stripeResponseHandler(status, response) {
//        if (response.error) {
//            /* Visual feedback */
//            $form.find('[type=submit]').html('Try again');
//            /* Show Stripe errors on the form */
//            $form.find('.payment-errors').text(response.error.message);
//            $form.find('.payment-errors').closest('.row').show();
//        } else {
//            /* Visual feedback */
//            $form.find('[type=submit]').html('Processing <i class="fa fa-spinner fa-pulse"></i>');
//            /* Hide Stripe errors on the form */
//            $form.find('.payment-errors').closest('.row').hide();
//            $form.find('.payment-errors').text("");
//            // response contains id and card, which contains additional card details            
//            console.log(response.id);
//            console.log(response.card);
//            var token = response.id;
//            // AJAX - you would send 'token' to your server here.
//            $.post('/account/stripe_card_token', {
//                token: token
//            })
//                // Assign handlers immediately after making the request,
//                .done(function (data, textStatus, jqXHR) {
//                    $form.find('[type=submit]').html('Payment successful <i class="fa fa-check"></i>').prop('disabled', true);
//                })
//                .fail(function (jqXHR, textStatus, errorThrown) {
//                    $form.find('[type=submit]').html('There was a problem').removeClass('success').addClass('error');
//                    /* Show Stripe errors on the form */
//                    $form.find('.payment-errors').text('Try refreshing the page and trying again.');
//                    $form.find('.payment-errors').closest('.row').show();
//                });
//        }
//    });
//}
/* Fancy restrictive input formatting via jQuery.payment library*/
$('input[name=cardNumber]').payment('formatCardNumber');
$('input[name=cardCVC]').payment('formatCardCVC');
$('input[name=cardExpiry').payment('formatCardExpiry');

/* Form validation using Stripe client-side validation helpers */
jQuery.validator.addMethod("cardNumber", function (value, element) {
    return this.optional(element) || Stripe.card.validateCardNumber(value);
}, "Please specify a valid credit card number.");

jQuery.validator.addMethod("cardExpiry", function (value, element) {
    /* Parsing month/year uses jQuery.payment library */
    value = $.payment.cardExpiryVal(value);
    return this.optional(element) || Stripe.card.validateExpiry(value.month, value.year);
}, "Invalid expiration date.");

jQuery.validator.addMethod("cardCVC", function (value, element) {
    return this.optional(element) || Stripe.card.validateCVC(value);
}, "Invalid CVC.");

validator = $form.validate({
    rules: {
        cardNumber: {
            required: true,
            cardNumber: true
        },
        cardExpiry: {
            required: true,
            cardExpiry: true
        },
        cardCVC: {
            required: true,
            cardCVC: true
        }
    },
    highlight: function (element) {
        $(element).closest('.form-control').removeClass('success').addClass('error');
    },
    unhighlight: function (element) {
        $(element).closest('.form-control').removeClass('error').addClass('success');
    },
    errorPlacement: function (error, element) {
        $(element).closest('.form-group').append(error);
    }
});

paymentFormReady = function () {
    if ($form.find('[name=cardNumber]').hasClass("success") &&
        $form.find('[name=cardExpiry]').hasClass("success") &&
        $form.find('[name=cardCVC]').val().length > 1) {
        return true;
    } else {
        return false;
    }
}

$form.find('[type=submit]').prop('disabled', true);
var readyInterval = setInterval(function () {
    if (paymentFormReady()) {
        $form.find('[type=submit]').prop('disabled', false);
        clearInterval(readyInterval);
    }
}, 250);

//Dynamically change the value of total price

//$('#btn-num-up').click(function () {
//    var tot = $('#rentPerMonth').val() * $('#num-product1').value;
//    $('#perProductTotal').val(tot);
//});

function onQtyChangedUp() {

    var a = document.getElementById('num-product1').value;
    a = parseInt(a) + 1;
    var b = document.getElementById('rentPerMonth').innerHTML;
    var d = document.getElementById('ProductsInCart_0__RentalDurationInMonths').value;
    //alert(d);
    var total = 0.0;
    var taxesApplied2 = 0.0;
    var totalRentalAmt2 = 0.0;
    var discountApplied2 = 0.0;
    var rentalAmt2 = 0.0;
    var totalRentalDep2 = 0.0;
    var couponCode = 0.0;

    var c = d * a * b;
    document.getElementById('perProductTotal').innerHTML = c;

    var allProducts = document.getElementById("perProductTotal");
    for (var i = 0; i < allProducts.length; i++) {
        totalRentalAmt2 += Int.parseInt(allProducts[i].innerHTML);
    }


    couponCode = document.getElementById('coupon');
    if (couponCode !== null) {
        if (couponCode.innerHTML === "DISCOUNT10") {
            discountApplied2 = 0.10 * totalRentalAmt2;
        }
        else if (couponCode.innerHTML === "DISCOUNT15") {
            discountApplied2 = 0.15 * totalRentalAmt2;
        }
        else if (couponCode.innerHTML === "DISCOUNT20") {
            discountApplied2 = 0.2 * totalRentalAmt2;
        }
        else if (couponCode.innerHTML === "DISCOUNT50") {
            discountApplied2 = 0.5 * totalRentalAmt2;
        }
        else {
            alert("INVALID COUPON CODE! PLEASE TRY WITH A VALID COUPON CODE");
        }

    }
    

    taxesApplied2 = 0.05 * totalRentalAmt2;

    totalRentalDep2 = 0.10 * totalRentalAmt2;

    total = taxesApplied2 + totalRentalAmt2 + totalRentalDep2 - discountApplied2;


    document.getElementById('subtotalCart').innerHTML = totalRentalAmt2;
    document.getElementById('rentalDepositCart').innerHTML = totalRentalDep2;
    document.getElementById('discountCart').innerHTML = discountApplied2;
    document.getElementById('taxesAppliedCart').innerHTML = taxesApplied2;
    document.getElementById('Total').innerHTML = total;

    
    


}

function onQtyChangedDown() {

    var a = document.getElementById('num-product1').value;
    a = parseInt(a) - 1;
    var b = document.getElementById('rentPerMonth').innerHTML;
    var d = document.getElementById('ProductsInCart_0__RentalDurationInMonths').value;

    var c = d * a * b;
    document.getElementById('perProductTotal').innerHTML = c;


   

}

function getTotal() {
    var total = 0;
    var perProductTotal = document.getElementById('perProductTotal');
    total += parseFloat(perProductTotal.innerHTML);
    $('#cartProduct_TotalCostForProduct').text(total);
}


//$('#btnAddToCart').click(function (e) {
//    //e.preventDefault();
//    var itemsInCart = $(this).attr('itemsInCart');
//    $('#cartNotification').attr('data-notify', itemsInCart)
//});


function updateCartNotification(count) {
    
    alert(count);
    $('#cartNotification').removeAttr('data-notify');
    $('#cartNotification').attr('data-notify', count);
}

