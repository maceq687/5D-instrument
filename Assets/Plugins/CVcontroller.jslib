mergeInto(LibraryManager.library, {

    ControlVideoStream: function(name) {
        var objName = Pointer_stringify(name);
        ControlStream(objName);
    },

});