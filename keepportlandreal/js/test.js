/**
 * Created by marty on 10/23/16.
 */
var test = (function () {
    function test() {
        this.name = "test";
    }
    test.prototype.showTest = function (a) {
        console.log(a);
    };
    return test;
}());
(function () {
    var t = new test();
    t.showTest(t.name);
})();
//# sourceMappingURL=test.js.map