/*==================================================================
    contact liên hệ*/
document.addEventListener("DOMContentLoaded", () => {
  const name = document.getElementById("name");
  const content = document.getElementById("content");
  const submit = document.getElementById("submit");
  submit.addEventListener("click", (e) => {
    e.preventDefault();
    const data = {
      name: name.value,

      content: content.value,
    };
    postGoogle(data);
  });
  async function postGoogle(data) {
    const formURL =
      "https://docs.google.com/forms/u/1/d/e/1FAIpQLScVBmA1JNDK3RTg73E3NEXwpipUEzeSAWL8o290BBz3txwXFA/formResponse";
    const formdata = new FormData();
    formdata.append("entry.1567585520", data.name);
    formdata.append("entry.2111944419", data.content);
    await fetch(formURL, {
      method: "POST",
      body: formdata,
    });
  }
});
