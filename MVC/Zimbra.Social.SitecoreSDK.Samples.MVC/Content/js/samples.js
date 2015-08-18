(function ($) {

    var api = {
        comment: {
            register: function(options) {
                var self = this;

                $('.comment-button').on('click', function () {
                    var data = { body: $('#comment-body').val() };
                    if (options.url && options.url.length > 0) data.url = options.url;
                    if (options.contentId && options.contentId.length > 0) data.contentId = options.contentId;
                    if (options.contentTypeId && options.contentTypeId.length > 0) data.contentTypeId = options.contentTypeId;

                    $.post(options.createCommentUrl, data)
                    .done(function (result) {
                        $('.comment-list').append(self.render(result));
                        $('#comment-body').val('');
                    });

                    return false;
                });
                
                return this;
            },
            render : function(data) {

                return '<li class="comment-list-item">' +
                    '<div class="comment-header ">' +
                        '<ul class="meta list-inline">' +
                            '<li class="author">' + data.Comment.User.DisplayName + '</li>' +
                            '<li class="post-date">Now</li>' +
                        '</ul>' +
                    '</div>' +
                    '<p> ' + data.Comment.Body + '</p>' +
                '</li>';
            }
        },
        like: {
            register: function (options) {
                var self = this;

                $('.likes').html(self.render({
                    TotalCount: options.totalCount,
                    Class: options.isLiked ? 'unlike' : 'like',
                    Value: options.isLiked ? 'Unlike' : 'Like'
                }));

                $(document).on('click', '.like', function(){
                    var data = {};
                    if (options.url && options.url.length > 0) data.url = options.url;
                    if (options.contentId && options.contentId.length > 0) data.contentId = options.contentId;
                    if (options.contentTypeId && options.contentTypeId.length > 0) data.contentTypeId = options.contentTypeId;

                    $.post(options.createLikeUrl, data)
                    .done(function (result) {
                        
                        result.Class = 'unlike';
                        result.Value = 'Unlike';
                        result.TotalCount = ++options.totalCount;

                        $('.likes').html(self.render(result));
                    });

                    return false;
                });

                $(document).on('click', '.unlike', function(){
                    var data = {};
                    if (options.url && options.url.length > 0) data.url = options.url;
                    if (options.contentId && options.contentId.length > 0) data.contentId = options.contentId;
                    
                    $.post(options.deleteLikeUrl, data)
                    .done(function () { $('.likes').html(self.render()); });

                    return false;
                });

                return this;
            },
            render: function (data) {
                data = data || { TotalCount: 0, Class: 'like', Value: 'Like' };

                if (data.Errors && data.Errors.length > 0) {
                    return '<div class="alert alert-danger" role="alert">' + data.Errors[0] + '</div>';
                }

                return '<a href="javascript:void(0)" class="' + data.Class + '">' + data.Value + ' <i class="fa fa-thumbs-up"></i> ' + data.TotalCount + ' </a>';
            }
        },
        rate: {
            register: function (options) {
                var score = Math.min(Math.ceil(options.score * 5), 5);
                $('.ratings').raty({ path: '/Content/images', score: score, click : function(score) {
                    var data = { Score: score/5 };
                    if (options.url && options.url.length > 0) data.url = options.url;
                    if (options.contentId && options.contentId.length > 0) data.contentId = options.contentId;
                    if (options.contentTypeId && options.contentTypeId.length > 0) data.contentTypeId = options.contentTypeId;

                    $.post(options.rateCreateUrl, data);
                } });
                return this;
            }
        }
    };

    $.social = $.social || {};
    $.social.api = $.social.api || api;

})(jQuery);