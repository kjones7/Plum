﻿export var idNames = {
    videoUrl: 'video-url',
    createAnnotationButton: 'create-annotation-btn',
    annotationsBody: 'annotations-body',
    noAnnotationsText: 'no-annotation-text',
    annotations: 'annotations',
    filterAnnotationsList: 'filter-annotations-list',
    libraryId: 'library-id'
};

export var classNames = {
    createAnnotation: 'create-annotation-container',
    cancelAnnotation: 'cancel-annotation',
    newAnnotationTimestamp: 'timestamp',
    submitAnnotation: 'submit-annotation',
    videoId: 'video-id',
    toggleRepliesButton: 'toggle-replies',
    replyButton: 'reply-button',
    createReplyControls: 'create-reply-container',
    annotationWrapper: 'annotation-wrapper',
    cancelCreateReplyButton: 'cancel-reply',
    submitReply: 'submit-reply',
    annotationReplies: 'annotation-replies',
    displayName: 'display-name',
    editAnnotation: 'edit-annotation',
    annotationBody: 'annotation-body',
    deleteAnnotation: 'delete-annotation',
    cancelEditAnnotation: 'cancel-edit-annotation',
    annotationText: 'annotation-text',
    editAnnotationTextWrapper: 'edit-annotation-text-wrapper',
    editReply: 'edit-reply',
    deleteReply: 'delete-reply',
    replyContainer: 'reply-container',
    replyBody: 'reply-body',
    replyText: 'reply-text',
    cancelEditReply: 'cancel-edit-reply',
    editReplyTextWrapper: 'edit-reply-text-wrapper',
    submitEditReply: 'submit-edit-reply',
    toggleRepliesWrapper: 'toggle-replies-wrapper'
};

export var selectors = {
    createAnnotationTextarea: '.create-annotation-container textarea',
    displayName: `.${classNames.displayName}`,
    filterAnnotationsList: `#${idNames.filterAnnotationsList}`,
    noAnnotationsText: `#${idNames.noAnnotationsText}`,
    filterAnnotationsListEntry: `#${idNames.filterAnnotationsList} li`,
    editAnnotation: `#${idNames.annotations} a.${classNames.editAnnotation}`,
    annotationWrapper: `.${classNames.annotationWrapper}`,
    annotationBody: `.${classNames.annotationBody}`,
    annotationText: `.${classNames.annotationText}`,
    editAnnotationTextWrapper: `.${classNames.editAnnotationTextWrapper}`,
    editAnnotationText: `.${classNames.editAnnotationTextWrapper} textarea`,
    replyContainer: `.${classNames.replyContainer}`,
    replyBody: `.${classNames.replyBody}`,
    replyText: `.${classNames.replyText}`,
    cancelEditReply: `.${classNames.cancelEditReply}`,
    editReplyTextWrapper: `.${classNames.editReplyTextWrapper}`,
    editReplyText: `.${classNames.editReplyTextWrapper} textarea`,
    submitEditReply: `.${classNames.submitEditReply}`,
    libraryId: `#${idNames.libraryId}`,
    toggleRepliesWrapper: `.${classNames.toggleRepliesWrapper}`,
    annotationReplies: `.${classNames.annotationReplies}`
};

export var elements = {
    videoUrl: document.getElementById(idNames.videoUrl),
    createAnnotation: document.querySelector('.' + classNames.createAnnotation),
    createAnnotationButton: document.getElementById(idNames.createAnnotationButton),
    cancelAnnotation: document.querySelector('.' + classNames.cancelAnnotation),
    newAnnotationTimestamp: document.querySelector('.' + classNames.newAnnotationTimestamp),
    createAnnotationTextarea: document.querySelector(selectors.createAnnotationTextarea),
    videoId: document.querySelector('.' + classNames.videoId),
    annotationsBody: document.getElementById(idNames.annotationsBody),
    noAnnotationsText: document.getElementById(idNames.noAnnotationsText),
    annotations: document.getElementById(idNames.annotations),
};

export var apiUrls = {
    submitAnnotation: '/Videos/' + elements.videoId.value + '?handler=CreateAnnotation',
    submitReply: '/Videos/' + elements.videoId.value + '?handler=CreateReply',
    editAnnotation: '/Videos/' + elements.videoId.value + '?handler=EditAnnotation',
    deleteAnnotation: '/Videos/' + elements.videoId.value + '?handler=DeleteAnnotation',
    editReply: '/Videos/' + elements.videoId.value + '?handler=EditReply',
    deleteReply: '/Videos/' + elements.videoId.value + '?handler=DeleteReply',
    fetchRole: '/Videos/' + elements.videoId.value + '?handler=FetchRole'
};