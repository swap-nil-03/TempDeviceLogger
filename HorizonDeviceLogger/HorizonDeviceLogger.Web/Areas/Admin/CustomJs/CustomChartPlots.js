/// <reference path="../../../scripts/jquery-3.3.1.min.js" />

var MaxPlotData = 50;
//Volt
var VoltConfig = {
    type: 'line',
    data: {
        labels: ['0'],
        datasets: [{
            label: 'VY',
            backgroundColor: "#eb3434",
            borderColor: "#eb3434",
            //data: [0],
            borderWidth: 2,
            pointRadius: 0,
            lineTension: 0,
            fill: false,
        }, {
            label: 'VR',
            backgroundColor: "#37eb34",
            borderColor: "#37eb34",
            //data: [0],
            borderWidth: 2,
            pointRadius: 0,
            lineTension: 0,
            fill: false,
        },
        {
            label: 'VB',
            backgroundColor: "#3471eb",
            borderColor: "#3471eb",
            //data: [0],
            borderWidth: 2,
            pointRadius: 0,
            lineTension: 0,
            fill: false,
        }]
    },
    options: {
        responsive: true,
        legend: {
            labels: {
                fontColor: "white",
            }
        },
        title: {
            display: true,
            text: 'Volt Realtime Data',
            fontColor: 'white',
        },
        tooltips: {
            mode: 'index',
            intersect: false,
        },
        hover: {
            mode: 'nearest',
            intersect: true
        },
        scales: {
            xAxes: [{
                display: false,
                scaleLabel: {
                    display: true,
                    labelString: 'Volt Data',
                    fontColor: 'white',
                },
                ticks: {
                    fontColor: "white", // To format the ticks, coming on the axis/lables which we are passing.                               
                }
            }],
            yAxes: [{
                display: true,
                scaleLabel: {
                    display: true,
                    labelString: 'Volt',
                    fontColor: 'white',
                },
                ticks: {
                    fontColor: "white", // To format the ticks, coming on the axis/lables which we are passing.                               
                }
            }]
        }
    }
};
function VoltRemovePlots() {
    if (VoltConfig.data.datasets.length > 0) {
        if (VoltConfig.data.datasets[0].data.length > MaxPlotData) {
            VoltConfig.data.labels.shift(); // remove the label first

            VoltConfig.data.datasets.forEach(function (dataset) {
                dataset.data.shift();
            });
        }
        window.VoltLine.update();
    }
}
function VoltAddPlots(voltData, time) {
    if (VoltConfig.data.datasets.length > 0) {
        VoltConfig.data.labels.push(time);

        VoltConfig.data.datasets.forEach(function (dataset, index) {
            dataset.data.push(voltData[index]);
        });

        window.VoltLine.update();
    }
}
function VoltAutoAdd(voltData, time) {
    VoltRemovePlots();
    VoltAddPlots(voltData, time);
}

//Current
var CurrentConfig = {
    type: 'line',
    data: {
        labels: ['0'],
        datasets: [{
            label: 'IY',
            backgroundColor: "#eb3434",
            borderColor: "#eb3434",
            //data: [0],
            borderWidth: 2,
            pointRadius: 0,
            lineTension: 0,
            fill: false,
        }, {
            label: 'IR',
            backgroundColor: "#37eb34",
            borderColor: "#37eb34",
            //data: [0],
            borderWidth: 2,
            pointRadius: 0,
            lineTension: 0,
            fill: false,
        },
        {
            label: 'IB',
            backgroundColor: "#3471eb",
            borderColor: "#3471eb",
            //data: [0],
            borderWidth: 2,
            pointRadius: 0,
            lineTension: 0,
            fill: false,
        }]
    },
    options: {
        responsive: true,
        legend: {
            labels: {
                fontColor: "white",
            }
        },
        title: {
            display: true,
            text: 'Current Realtime Data',
            fontColor: 'white',
        },
        tooltips: {
            mode: 'index',
            intersect: false,
        },
        hover: {
            mode: 'nearest',
            intersect: true
        },
        scales: {
            xAxes: [{
                display: false,
                scaleLabel: {
                    display: true,
                    labelString: 'Current Data',
                    fontColor: 'white',
                },
                ticks: {
                    fontColor: "white",
                }
            }],
            yAxes: [{
                display: true,
                scaleLabel: {
                    display: true,
                    labelString: 'Current',
                    fontColor: 'white',
                },
                ticks: {
                    fontColor: "white",
                }
            }]
        }
    }
};
function CurrentRemovePlots() {
    if (CurrentConfig.data.datasets.length > 0) {
        if (CurrentConfig.data.datasets[0].data.length > MaxPlotData) {
            CurrentConfig.data.labels.shift(); // remove the label first

            CurrentConfig.data.datasets.forEach(function (dataset) {
                dataset.data.shift();
            });
        }
        window.CurrentLine.update();
    }
}
function CurrentAddPlots(voltData, time) {
    if (CurrentConfig.data.datasets.length > 0) {
        CurrentConfig.data.labels.push(time);

        CurrentConfig.data.datasets.forEach(function (dataset, i) {
            dataset.data.push(voltData[i]);
        });

        window.CurrentLine.update();
    }
}
function CurrentAutoAdd(voltData, time) {
    CurrentRemovePlots();
    CurrentAddPlots(voltData, time);
}

//KWH Chart
//KWH
var KWHMaxPlotData = 200;
var KWHConfig = {
    type: 'bar',
    data: {
        labels: ['0'],
        datasets: [{
            label: 'KWH',
            backgroundColor: "orange",
            borderColor: "orange",
            //data: [0],
            borderWidth: 2,
            pointRadius: 0,
            lineTension: 0,
            fill: false,
        }]
    },
    options: {
        responsive: true,
        legend: {
            labels: {
                fontColor: "white",
            }
        },
        title: {
            display: true,
            text: 'KWH Realtime Data',
            fontColor: 'white',
        },
        tooltips: {
            mode: 'index',
            intersect: false,
        },
        hover: {
            mode: 'nearest',
            intersect: true
        },
        scales: {
            xAxes: [{
                display: false,
                scaleLabel: {
                    display: true,
                    labelString: 'KWH Data',
                    fontColor: 'white',
                },
                ticks: {
                    fontColor: "white",
                }
            }],
            yAxes: [{
                display: true,
                scaleLabel: {
                    display: true,
                    labelString: 'KWH',
                    fontColor: 'white',
                },
                ticks: {
                    fontColor: "white",
                }
            }]
        }
    }
};
function KWHRemovePlots() {
    if (KWHConfig.data.datasets.length > 0) {
        if (KWHConfig.data.datasets[0].data.length > KWHMaxPlotData) {
            KWHConfig.data.labels.shift(); // remove the label first

            KWHConfig.data.datasets.forEach(function (dataset) {
                dataset.data.shift();
            });
        }
        window.KWHLine.update();
    }
}
function KWHAddPlots(Data, time) {
    if (KWHConfig.data.datasets.length > 0) {
        KWHConfig.data.labels.push(time);

        KWHConfig.data.datasets.forEach(function (dataset, index) {
            dataset.data.push(Data);
        });

        window.KWHLine.update();
    }
}
function KWHAutoAdd(Data, time) {
    KWHRemovePlots();
    KWHAddPlots(Data, time);
}

//KVAH
var KVAHConfig = {
    type: 'bar',
    data: {
        labels: ['0'],
        datasets: [{
            label: 'KVAH',
            backgroundColor: "cyan",
            borderColor: "cyan",
            //data: [0],
            borderWidth: 2,
            pointRadius: 0,
            lineTension: 0,
            fill: false,
        }]
    },
    options: {
        responsive: true,
        legend: {
            labels: {
                fontColor: "white",
            }
        },
        title: {
            display: true,
            text: 'KVAH Realtime Data',
            fontColor: 'white',
        },
        tooltips: {
            mode: 'index',
            intersect: false,
        },
        hover: {
            mode: 'nearest',
            intersect: true
        },
        scales: {
            xAxes: [{
                display: false,
                scaleLabel: {
                    display: true,
                    labelString: 'KVAH Data',
                    fontColor: 'white',
                },
                ticks: {
                    fontColor: "white",
                }
            }],
            yAxes: [{
                display: true,
                scaleLabel: {
                    display: true,
                    labelString: 'KVAH',
                    fontColor: 'white',
                },
                ticks: {
                    fontColor: "white",
                }
            }]
        }
    }
};
function KVAHRemovePlots() {
    if (KVAHConfig.data.datasets.length > 0) {
        if (KVAHConfig.data.datasets[0].data.length > MaxPlotData) {
            KVAHConfig.data.labels.shift(); // remove the label first

            KVAHConfig.data.datasets.forEach(function (dataset) {
                dataset.data.shift();
            });
        }
        window.KVAHLine.update();
    }
}
function KVAHAddPlots(Data, time) {
    if (KVAHConfig.data.datasets.length > 0) {
        KVAHConfig.data.labels.push(time);

        KVAHConfig.data.datasets.forEach(function (dataset, index) {
            dataset.data.push(Data);
        });

        window.KVAHLine.update();
    }
}
function KVAHAutoAdd(Data, time) {
    KVAHRemovePlots();
    KVAHAddPlots(Data, time);
}

//KVA
var KVAConfig = {
    type: 'bar',
    data: {
        labels: ['0'],
        datasets: [{
            label: 'KVA',
            backgroundColor: "#ff4d4d",
            borderColor: "#ff4d4d",
            //data: [0],
            borderWidth: 2,
            pointRadius: 0,
            lineTension: 0,
            fill: false,
        }]
    },
    options: {
        responsive: true,
        legend: {
            labels: {
                fontColor: "white",
            }
        },
        title: {
            display: true,
            text: 'KVA Realtime Data',
            fontColor: 'white',
        },
        tooltips: {
            mode: 'index',
            intersect: false,
        },
        hover: {
            mode: 'nearest',
            intersect: true
        },
        scales: {
            xAxes: [{
                display: false,
                scaleLabel: {
                    display: true,
                    labelString: 'KVA Data',
                    fontColor: 'white',
                },
                ticks: {
                    fontColor: "white",
                }
            }],
            yAxes: [{
                display: true,
                scaleLabel: {
                    display: true,
                    labelString: 'KVA',
                    fontColor: 'white',
                },
                ticks: {
                    fontColor: "white",
                }
            }]
        }
    }
};
function KVARemovePlots() {
    if (KVAConfig.data.datasets.length > 0) {
        if (KVAConfig.data.datasets[0].data.length > MaxPlotData) {
            KVAConfig.data.labels.shift(); // remove the label first

            KVAConfig.data.datasets.forEach(function (dataset) {
                dataset.data.shift();
            });
        }
        window.KVALine.update();
    }
}
function KVAAddPlots(Data, time) {
    if (KVAConfig.data.datasets.length > 0) {
        KVAConfig.data.labels.push(time);

        KVAConfig.data.datasets.forEach(function (dataset, index) {
            dataset.data.push(Data);
        });

        window.KVALine.update();
    }
}
function KVAAutoAdd(Data, time) {
    KVARemovePlots();
    KVAAddPlots(Data, time);
}


//PFR
var PFRConfig = {
    type: 'bar',
    data: {
        labels: ['0'],
        datasets: [{
            label: 'PFR',
            backgroundColor: "cyan",
            borderColor: "cyan",
            //data: [0],
            borderWidth: 2,
            pointRadius: 0,
            lineTension: 0,
            fill: false,
        }]
    },
    options: {
        responsive: true,
        legend: {
            labels: {
                fontColor: "white",
            }
        },
        title: {
            display: true,
            text: 'PFR Realtime Data',
            fontColor: 'white',
        },
        tooltips: {
            mode: 'index',
            intersect: false,
        },
        hover: {
            mode: 'nearest',
            intersect: true
        },
        scales: {
            xAxes: [{
                display: false,
                scaleLabel: {
                    display: true,
                    labelString: 'PFR Data',
                    fontColor: 'white',
                },
                ticks: {
                    fontColor: "white",
                }
            }],
            yAxes: [{
                display: true,
                scaleLabel: {
                    display: true,
                    labelString: 'PFR',
                    fontColor: 'white',
                },
                ticks: {
                    fontColor: "white",
                }
            }]
        }
    }
};
function PFRRemovePlots() {
    if (PFRConfig.data.datasets.length > 0) {
        if (PFRConfig.data.datasets[0].data.length > MaxPlotData) {
            PFRConfig.data.labels.shift(); // remove the label first

            PFRConfig.data.datasets.forEach(function (dataset) {
                dataset.data.shift();
            });
        }
        window.PFRLine.update();
    }
}
function PFRAddPlots(Data, time) {
    if (PFRConfig.data.datasets.length > 0) {
        PFRConfig.data.labels.push(time);

        PFRConfig.data.datasets.forEach(function (dataset, index) {
            dataset.data.push(Data);
        });

        window.PFRLine.update();
    }
}
function PFRAutoAdd(Data, time) {
    PFRRemovePlots();
    PFRAddPlots(Data, time);
}

//Common Timer
function GetTime() {
    var tt = new Date();
    return tt.getHours().toString() + ":" + tt.getMinutes().toString() + "." + tt.getSeconds().toString();
}

function GetFormattedTime(rcvdTime) {
    //var tt = new Date(rcvdTime);
    //return tt.getHours().toString() + ":" + tt.getMinutes().toString() + "." + tt.getSeconds().toString();
    return rcvdTime;
}

