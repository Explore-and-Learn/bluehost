/**
 * Created by marty on 10/23/16.
 */
class test {
  public name : string = "test";

  showTest(a:string) {
    console.log(a);
  }
}

(function(){

  var t = new test();
  t.showTest(t.name);
})();