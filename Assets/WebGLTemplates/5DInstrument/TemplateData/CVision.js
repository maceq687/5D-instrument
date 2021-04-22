navigator.getUserMedia = 
    navigator.getUserMedia 
    || navigator.webkitgetUserMedia
    || navigator.mozGetgetUserMedia 
    || navigator.msGetgetUserMedia;

const modelParams = {
    flipHorizontal: true,   // flip e.g for video 
    imageScaleFactor: 0.7,  // reduce input image size for gains in speed.
    maxNumBoxes: 1,         // maximum number of boxes to detect
    iouThreshold: 0.5,      // ioU threshold for non-max suppression
    scoreThreshold: 0.7,    // confidence threshold for predictions.
}

const video = document.querySelector('#video');
const canvas = document.querySelector('#canvas');
const context = canvas.getContext('2d');

let model; 

handTrack.startVideo(video).then(status => {
    if(status){
        navigator.getUserMedia(
            { video:{} },
            stream => {
                video.srcObject = stream;
                setInterval(runDetection, 10);
            },
            err =>console.log(err)
        );
    }
});

function runDetection(){
    model.detect(video).then(predictions => {
        model.renderPredictions(predictions, canvas, context, video);
        // console.log(predictions);
        if (predictions[0]) {
            var xPrmtr = midval = predictions[0].bbox[0] + (predictions[0].bbox[2] / 2)
            var yPrmtr = predictions[0].bbox[1] + (predictions[0].bbox[3] / 2);
            xPrmtr = xPrmtr / 640; // wideo width
            yPrmtr = yPrmtr / 480; // wideo height
            var obj = {"xHand": xPrmtr, "yHand": yPrmtr};
            // console.log(obj);
            unityInstance.SendMessage('BotBlue', 'Move', JSON.stringify(obj))
        }
    });
}
handTrack.load(modelParams).then(lmodel => {
    model = lmodel;
});