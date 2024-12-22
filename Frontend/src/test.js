import {ref,reactive}from Vue;
const app = {
  data() {
    const settings = {
      msg: "Hello from Vue",
      count: ref(0),
      counter: reactive({ count: 0 }),
    };
    function increment() {
      settings.count.value++;
      console.log(`It works ${settings.count}`);
    }
    settings.inc = increment;
    return settings;
  },
};

Vue.createApp(app).mount("#app");
