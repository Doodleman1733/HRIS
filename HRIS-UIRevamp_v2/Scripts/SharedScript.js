function initiateSharedUI() {

    //$('.c-checkbox').iCheck({
    //    checkboxClass: 'icheckbox_minimal',
    //    cursor: true
    //});

    //$('.c-radio').iCheck({
    //    radioClass: 'iradio_minimal',
    //    cursor: true
    //});

    //$('.b-cancel').click(function (e) {
    //    _this = this;
    //    e.preventDefault();
    //    return bootbox.confirm("Are you sure you want to exit?", function (result) {
    //        if (result) {
    //            window.location = $(_this).attr('href');
    //        } 
    //    });
    //});

    //var loader = new Loader();

    $('.contact').inputmask("+63 (999) 999-9999");

    $('.time').inputmask(
    "hh:mm",
    {
        placeholder: "HH:MM",
        insertMode: false,
        showMaskOnHover: false,
        //hourFormat: 12,
        mask: "h:s",
        onincomplete: function () {
            _this = $(this);
            _this.val(_this.val().replace(/H|M/gi, 0)).trigger('change');
        }
    }
    );

    $('.floatingLabel').floatinglabel({
        animationIn: { top: '-5px', opacity: '1' },
        animationOut: { top: '0', opacity: '0' },

        labelClass: 'floating-label',
        pinClass: 'pinblack ',

        delayIn: 300,
        delayOut: 300,
        easingIn: false,
        easingOut: false
    });

   // $('.time').inputmask(
   //"hh:mm",
   //{
   //    placeholder: "HH:MM am",
   //    insertMode: false,
   //    showMaskOnHover: false,
   //    hourFormat: 12,
   //    mask: "h:s a\\m",
   //    onincomplete: function () {
   //        _this = $(this);
   //        _this.val(_this.val().replace(/H|M/gi, 0)).trigger('change');
   //    }
   //}
   //).focus(function () {
   //    $(this).selectRange(0, $(this).val().length);
   //});

    //$('.date-single').mask("99/99/9999", { placeholder: 'DD/MM/YYYY' });

    $(".int-min,.int-60").autoNumeric('init', {
        aSep: '',
        vMin: '0',
        vMax: '60',
        wEmpty: 'empty',
        lZero: 'deny',
        mDec: 0,
    });

    $(".int").autoNumeric('init', {
        aSep: '',
        vMin: '0',
        wEmpty: 'empty',
        lZero: 'deny',
        mDec: 0
    });

    $(".int-24").autoNumeric('init', {
        aSep: '',
        vMin: '0',
        vMax: '24',
        wEmpty: 'empty',
        lZero: 'deny',
        mDec: 0
    });

    $(".int-300").autoNumeric('init', {
        aSep: '',
        vMin: '0',
        vMax: '300',
        wEmpty: 'empty',
        lZero: 'deny',
        mDec: 0
    });


    $(".int-999").autoNumeric('init', {
        aSep: '',
        vMin: '0',
        vMax: '999',
        wEmpty: 'empty',
        lZero: 'deny',
        mDec: 0
    });

    $(".int-9999").autoNumeric('init', {
        aSep: '',
        vMin: '0',
        vMax: '999',
        wEmpty: 'empty',
        lZero: 'deny',
        mDec: 0
    });

    $(".int-99999").autoNumeric('init', {
        aSep: '',
        vMin: '0',
        vMax: '99999',
        wEmpty: 'empty',
        lZero: 'deny',
        mDec: 0
    });

    $(".dec-1-2").autoNumeric('init', {
        aSep: ',',
        aDec: '.',
        vMin: '0',
        vMax: '9.99',
        wEmpty: 'empty',
        lZero: 'deny',
        mDec: 2
    });

    $(".dec-2-2").autoNumeric('init', {
        aSep: ',',
        aDec: '.',
        vMin: '0',
        vMax: '99.99',
        wEmpty: 'empty',
        lZero: 'deny',
        mDec: 2
    });

    $(".dec-3-2").autoNumeric('init', {
        aSep: ',',
        aDec: '.',
        vMin: '0.00',
        vMax: '99.99',
        wEmpty: 'empty',
        lZero: 'deny',
        mDec: 2
    });

    $(".dec-4-2").autoNumeric('init', {
        aSep: ',',
        aDec: '.',
        vMin: '0',
        vMax: '999.99',
        wEmpty: 'empty',
        lZero: 'deny',
        mDec: 2
    });

    $(".dec-5-2").autoNumeric('init', {
        aSep: ',',
        aDec: '.',
        vMin: '0',
        vMax: '999.99',
        wEmpty: 'empty',
        lZero: 'deny',
        mDec: 2
    });

    $(".dec-money").autoNumeric('init', {
        aSep: ',',
        aDec: '.',
        vMin: '0',
        vMax: '9999999999999999',
        wEmpty: 'empty',
        lZero: 'deny',
        mDec: 2
    });

    $('[data-toggle="tooltip"]').tooltip({ animated: 'fade', html: true, 'container': 'body' });

    //bootbox.setDefaults({
    //    size: 'small',
    //    className: "cust-modal"
    //});

    markRequired();

    //$("[data-val-length-max]").each(function () {
    //    var _this = $(this);
    //    var data = _this.data();
    //    _this.attr("maxlength", data.valLengthMax);
    //});

    $('input[type=text]').attr('autocomplete', 'off');

    //$('[data-val-date]').removeAttr('data-val-date');

    $.validator.addMethod("greaterThan", function (value, element) {
        var $min = $(element).closest('form').find("#" + $(element).data('linked'));
        if (this.settings.onfocusout) {
            $min.off(".validate-greaterThan").on("blur.validate-greaterThan", function () {
                $(element).valid();
            });
        }
        return parseInt(value) > parseInt($min.val());
    }, function (params, element) {
        return $(element).is('[data-val-linked]') ? $(element).data('val-linked') : "Must be greater than previous field";
    });

    $.validator.addMethod("atLeastOne", function (value, elem, param) {
        if ($(".atLeastOne:checkbox:checked").length > 0) {
            $('#atLeastOne').text('');
            return true;
        } else {
            $('#atLeastOne').text('Select at least one.');
            return false;
        }
    }, "Select at least one cut one.");

    //$.validator.addMethod("requiredIfBoth", function (value, element) {
    //    var $min = $(element).closest('form').find("#" + $(element).data('required-if-both'));
    //    if (this.settings.onfocusout) {
    //        $min.off(".validate-requiredIfBoth").on("blur.validate-requiredIfBoth", function () {
    //            $(element).valid();
    //        });
    //    }
    //    return (!$min.val().length || ($min.val().length && value.length));
    //}, function (params, element) {
    //    return $(element).is('[data-val-required-if-both]') ? $(element).data('val-required-if-both') : "This field is required";
    //});


    $.validator.addClassRules({
        max: {
            greaterThan: true
        },
        requiredIfBoth: {
            requiredIfBoth: true
        },
        atLeastOne: {
            atLeastOne: true
        }
    });

    //$(document).ajaxStart(function (handler) {
    //    loader.show();
    //}).ajaxStop(function () {
    //    loader.hide();
    //    markRequired();
    //}).ajaxError(function (event, jqxhr, settings, thrownError) {
    //    loader.hide();
    //    if (jqxhr.status == 401) {
    //        // perform a redirect to the login page since we're no longer authorized
    //        bootbox.alert('Session expired.', function () {
    //            location.reload();
    //        });
    //    }else {    
    //        bootbox.alert({
    //            size: 'large',
    //            message: jqxhr.responseText
    //        });
    //    }
    //});
}

$.fn.selectRange = function (start, end) {
    if (end === undefined) {
        end = start;
    }
    return this.each(function () {
        if ('selectionStart' in this) {
            this.selectionStart = start;
            this.selectionEnd = end;
        } else if (this.setSelectionRange) {
            this.setSelectionRange(start, end);
        } else if (this.createTextRange) {
            var range = this.createTextRange();
            range.collapse(true);
            range.moveEnd('character', end);
            range.moveStart('character', start);
            range.select();
        }
    });
};

function markRequired() {
    $('[data-val-required]').not('input[type=checkbox]').each(function (index, elem) {
        var id = $(elem).attr('id');
        $('form label[for="' + id + '"]').addClass('lbl-req');
    });
    $('select[data-val-required]').each(function (index, elem) {
        $(elem).next('.selectize-control').find('input').attr('data-val-required','required');
    });
}

function clonePaginate(elem) {

    $('.cloned-elem[data-id=' + elem.id + ']').remove();
    var clone   = $('<div/>', { 'class': 'cloned-elem', 'data-id': elem.id});
    var id      = 'dynatable-pagination-links-' + elem.id;
    var links = $('#dynatable-pagination-links-' + elem.id).clone(true).removeAttr('id');
    var pages = $('#dynatable-record-count-' + elem.id).clone(true).removeAttr('id');

    links.find('a').attr('data-target', id);
    links.find('.dynatable-page-next').attr('data-target', id);
    links.find('.dynatable-page-pre').attr('data-target', id);

    clone.append(links);
    clone.append(pages);
    $('#dynatable-processing-' + elem.id).before(clone);
    
    $('.dynatable-page-prev[data-target=' + id + ']').bind('click');
    $('.dynatable-page-next[data-target=' + id + ']').bind('click');
    $('.dynatable-page-link[data-target=' + id + ']').bind('click');

    $('.dynatable-page-prev[data-target=' + id + ']').click(function () {
        $('#' + $(this).attr('data-target') + ' .dynatable-page-prev').trigger('click');
    });

    $('.dynatable-page-next[data-target=' + id + ']').click(function () {
        $('#' + $(this).attr('data-target')+' .dynatable-page-next').trigger('click');
    });

    $('.dynatable-page-link[data-target=' + id + ']').click(function () {
        _this = $(this);
        _this.addClass('dynatable-active-page');
        $('#' + _this.attr('data-target')+' .dynatable-page-link[data-dynatable-page=' + _this.attr('data-dynatable-page') + ']').trigger('click');
    });

}

function getTimeDiff(start, end) {
    var nstart = moment('1970-01-01 ' + start);
    var nEnd = moment('1970-01-01 ' + end);
    var altEnd = moment('1970-01-02 ' + end);
    var ms = nEnd.isBefore(nstart) ? altEnd.diff(nstart) : nEnd.diff(nstart);
    var duration = moment.duration(ms);
    var hours = parseInt(duration.asHours());
    var minutes = parseInt(duration.asMinutes()) - hours * 60;
    return ((hours.toString().length == 1 ? '0' + hours : hours) + ':' + (minutes.toString().length == 1 ? minutes.toString() + '0' : minutes))
}

function subTime(main, sub) {
    var start = moment(main, "HH:mm");
    var time = sub.split(':');
    start.subtract((parseInt(time[0]) * 60) + parseInt(time[1]), 'minutes');
    return start.format("HH:mm");
}

function initiateSharedEvents() {

    //$(document).on("keydown", function (e) {
    //    if (e.which === 8 && !$(e.target).is("input, textarea")) {
    //        e.preventDefault();
    //    }
    //});

    $(document).on('input', '[maxlength]', function () {
        _this = $(this);
        if ($('[data-valmsg-for="' + _this.attr('id') + '"]').length > 0) {
            
            //if ($.validator) {
            //    var _getLength = $.validator.prototype.getLength;
            //    $.validator.prototype.getLength = function (value, element) {
            //        if (element.nodeName.toLowerCase() === 'textarea') {
            //            var newLineCharacterRegexMatch = /\r?\n|\r/g;
            //            if (element.value) {
            //                var regexResult = element.value.match(newLineCharacterRegexMatch);
            //                var newLineCount = regexResult ? regexResult.length : 0;
            //                var replacedValue = element.value.replace(newLineCharacterRegexMatch, "");
            //                return replacedValue.length + (newLineCount * 2);
            //            } else {
            //                return 0;
            //            }
            //        }
            //        return _getLength.apply(this, arguments);
            //    };
            //}

            $('[data-valmsg-for="' + _this.attr('id') + '"]').addClass('field-validation-error').html("<span class='char-count'  for=" + _this.attr('id') + " >" + (parseInt(_this.attr('maxlength')) - (_this.val().replace(/\r\n|\n|\r/g, '  ').length)) + '  characters remaining.' + ".</span>");
        } else {
            console.log()
            _this.after('<span data-valmsg-for="' + _this.attr('id') + '"></span>');
        }
    });

    //$(document).on('blur', '[maxlength]', function () {
    //    _this = $(this);
    //    $('[data-valmsg-for="' + _this.attr('id') + '"] .char-count').remove();
    //});

    //$(document).on('click', '#tog-scr', function (e) {
    //    e.preventDefault();
    //    $('#header').toggle();
    //    $('#sidebar').toggle();
    //    $('#content-container').toggleClass('col-md-11 col-md-12');
    //    $('#lower-container').toggleClass('pad-t-0');
    //    $(this).find('span').toggleClass('glyphicon-resize-full glyphicon-resize-small');
    //});
   
    //$(document).on('click', '#h-back', function () {
    //    window.history.back();
    //    window.location;
    //});

    $('a.disabled').on('click', function (e) {
        e.preventDefault();
    });

    
    $('#mn').scroll(function () {
        if (!window.matchMedia || (window.matchMedia("(max-width: 767px)").matches)) {
            var elem = $('.act-btns');
            elem.hide()
            setTimeout(function () {
               elem.show("slide");
            }, 2500);;
        }
    });   
}


function Loader(settings) {
    defaults = {
        template: '<div class="loader text-center"><h3><div class="loader-text"><span class=""><img id="loader-img">Loading...</div></h3></div>',
        elem :  $('body'),
    };

    this.settings = $.extend({}, defaults, settings);
}

//$(function () {
//    Loader.prototype.show = function () {
//        this.settings.elem.append(this.settings.template);
//    }

//    Loader.prototype.hide = function () {
//        $('.loader').hide('slow').remove();
//    }
//});

function FormPrompt(settings) {

    var defaults = {
        size: 'small',
        form: $("form"),
        message: 'Save?',
        ajax: false,
        ajaxConfig: {
            url: null,
            method: 'get',
            data: null,
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }
    };

    this.settings = $.extend({}, defaults, settings);

};

$(function () {
   

    FormPrompt.prototype.run = function () {

        var _this = this;

        _this.settings.form.submit(function (e) {

            if ($(this).valid()) {

                var cForm = this;
                e.preventDefault();
                if ($(".bootbox-confirm").length == 0) {
                    bootbox.confirm({
                        size: _this.settings.size,
                        message: _this.settings.message,
                        closeButton: false,
                        buttons: {
                            cancel: {
                                label: "NO",
                                className: "bg-orange001 text-white"
                            },
                            confirm: {
                                label: "YES",
                                className: "bg-green002 text-white"
                            }

                        },
                        className: "fs17 ff-nt2",
                        callback: function (result) {
                            if (result) {

                                $(cForm).find('input[type=text]').each(function (i, elem) {
                                    try {
                                        var v = $(elem).autoNumeric('get');
                                        $(elem).autoNumeric('destroy');
                                        $(elem).val(v);
                                    } catch (err) {
                                        console.log("Not an autonumeric field: " + $(elem).attr("name"));
                                    }
                                });

                                if (_this.settings.ajax == true) {
                                    var config = _this.settings.ajaxConfig;
                                    $.ajax({
                                        url: config.url,
                                        method: config.method,
                                        data: config.data,
                                        contentType: config.contentType,
                                        dataType: config.dataType,
                                        success: function (results) {
                                            _this.settings.form.trigger('form:ajaxSuccess', [_this, results]);
                                            $('html, body').animate({
                                                scrollTop: 0
                                            }, 0);
                                        }
                                    });
                                } else {
                                    cForm.submit();
                                }

                            }
                        }
                    });
                   
                }
                //else if ($(".bootbox-alert").length == 0) {
                //    bootbox.alert({
                //        size: _this.settings.size,
                //        message: _this.settings.message,
                //        closeButton: false,
                //        className: "fs17 ff-nt2",
                //        buttons: {
                //            ok:
                //                {
                //                    className: "bg-green002 text-white"
                //                }
                //        }
                //    });
                    
                //}
            } else {
                _this.settings.form.trigger('form:afterError', [_this,e]);
                $('html, body').animate({
                    scrollTop: $('.field-validation-error span:eq(0)').offset().top -100
                }, 0);
                $('.field-validation-error span:eq(0)').focus();
                e.preventDefault();
            }
        });

    };

});


function concat(a, b, c, d) {
    for (var x = a.toString().length; x < c; x++) {
        if (d) {
            a = a.toString() + b.toString();
        } else {
            a = b.toString() + a.toString();
        }
    }
    return a;
}

//function getValidDropDown(data, retainKey, retainValue) {
//    var rData = [];
//    for (var x in data) {
//        if ((data[x].Active && !data[x].Deleted) || (retainKey != null && retainValue  != null && retainKey.length && retainValue.length && [x][retainKey] == retainValue)) {
//            rData.push(data[x]);
//        }
//    }
//    return rData;
//}

$(document).ready(function () {

    initiateSharedUI();
    initiateSharedEvents();

});