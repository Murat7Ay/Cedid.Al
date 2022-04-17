abp.modals.MaterialModal = function () {
    function initModal(modalManager, args) {
        var $modal = modalManager.getModal();
        var $form = modalManager.getForm();
        $('#Material_KDVAmount').attr('readonly', 'true');
        $('#Material_Amount').attr('readonly', 'true');
        $('#Material_DiscountAmount').attr('readonly', 'true');
        $('#Material_DiscountTwoAmount').attr('readonly', 'true');
        $('#Material_NetAmount').attr('readonly', 'true');
        $("#Material_IsKDVIncluded,#Material_Quantity,#Material_Price,#Material_KDV,#Material_Discount,#Material_DiscountTwo").change(function () {
            var quantity = $('#Material_Quantity').val();
            var price = $('#Material_Price').val();
            var kdv = $('#Material_KDV').val();
            var discount = $('#Material_Discount').val();
            var discountTwo = $('#Material_DiscountTwo').val();
            var amount = price * quantity;
            var discountAmount = amount * (discount / 100);
            var discountTwoAmount = (amount - discountAmount) * (discountTwo / 100);
            $('#Material_KDVAmount').val((kdv / 100) * amount)
            $('#Material_Amount').val(amount);
            $('#Material_DiscountAmount').val(discountAmount);
            $('#Material_DiscountTwoAmount').val(discountTwoAmount);
            $('#Material_NetAmount').val(amount - discountAmount - discountTwoAmount);
        });
    };
    return {
        initModal: initModal
    };
};