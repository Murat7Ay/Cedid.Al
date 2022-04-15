abp.modals.MaterialModal = function () {
    function initModal(modalManager, args) {
        var $modal = modalManager.getModal();
        var $form = modalManager.getForm();
        $("input#ServiceMaterial_IsKDVIncluded,input#ServiceMaterial_Quantity,input#ServiceMaterial_Price,input#ServiceMaterial_KDV,input#ServiceMaterial_Discount,input#ServiceMaterial_DiscountTwo").change(function () {
            var quantity = $('input#ServiceMaterial_Quantity').val();
            var price = $('input#ServiceMaterial_Price').val();
            var kdv = $('input#ServiceMaterial_KDV').val();
            var discount = $('input#ServiceMaterial_Discount').val();
            var discountTwo = $('input#ServiceMaterial_DiscountTwo').val();
            var amount = price * quantity;
            var discountAmount = amount * (discount / 100);
            var discountTwoAmount = (amount - discountAmount) * (discountTwo / 100);
            $('input#ServiceMaterial_KDVAmount').val((kdv / 100) * amount)
            $('input#ServiceMaterial_Amount').val(amount);
            $('input#ServiceMaterial_DiscountAmount').val(discountAmount);
            $('input#ServiceMaterial_DiscountTwoAmount').val(discountTwoAmount);
            $('input#ServiceMaterial_NetAmount').val(amount - discountAmount - discountTwoAmount);
        });
    };
    return {
        initModal: initModal
    };
};