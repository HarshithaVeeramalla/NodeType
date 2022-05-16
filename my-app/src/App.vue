<template>
  <div id="nav">
    <router-link to="/">Home</router-link>
    <div class="rightalign">
      <router-link to="/emails">
        <button>Skriv dig up?</button><button>Hvad er Woof?</button><button>Kontakt</button>
      </router-link>
    </div>
  </div>
  <router-view :clearAnswer="clearAnswer" :Emails="Emails" :addEmail="addEmail"/>

</template>

<script>
export default {
  data: function () {
    return {
      Emails: [],
      showButton: true
    }
  },
  methods: {

    addEmail (Email) {
      if (Email) {
        this.Emails.push(Email)
        console.log(this.Emails)
      } else {
        console.log('No Email Found')
      }
    }
  }
}
</script>

<style>

</style>