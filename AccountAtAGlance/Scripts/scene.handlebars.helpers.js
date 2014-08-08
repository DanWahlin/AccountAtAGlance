Handlebars.registerHelper("getChangeCSSClass", function (change) {
    var val = parseFloat(change);
    return (val > 0) ? 'Positive' : 'Negative';
});

Handlebars.registerHelper("addPlus", function (value) {
    var val = parseFloat(value);
    return (val > 0) ? '+' : '';
});

Handlebars.registerHelper("addPlusMinus", function (value) {
    var val = parseFloat(value);
    return (val > 0) ? '+' : '-';
});