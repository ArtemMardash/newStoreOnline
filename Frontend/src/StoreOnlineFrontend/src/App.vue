<script setup>
import { RouterLink, RouterView } from 'vue-router'
</script>

<template>
  <header>
    <div class="wrapper">
      <nav>
        <RouterLink to="/">Home</RouterLink>
        <RouterLink to="/user">User</RouterLink>
        <RouterLink to="/order">Order</RouterLink>
      </nav>
    </div>
  </header>

  <RouterView />
</template>

<style scoped>
header {
  position: fixed;
  display: fixed;
  place-items: center;
  top: 0;
  left: 0;
  width: 100%;
  background-color: rgb(13, 107, 221);
  padding-right: calc(var(--section-gap) / 2);
  border-bottom: 1px solid var(--color-border);
}

.wrapper {
  display: flex;
  visibility: visible;
  opacity: 1;
  justify-content: space-between;
  align-items: center;
  place-items: inherit;
  flex-wrap: wrap;
}

.hidden {
  visibility: hidden;
}

nav {
  display: flex;
  width: 100%;
  font-size: 10px;
  text-align: top;
  margin-top: 10rem;

  text-align: top;
  margin-left: 1rem;
  font-size: 1rem;

  padding: 1rem 0;
  margin-top: 1rem;
}

nav a.router-link-exact-active {
  color: var(--color-text);
}

nav a.router-link-exact-active:hover {
  background-color: transparent;
}

nav a {
  display: flex;
  padding: 0 1rem;
  border-left: 1px solid var(--color-border);
}

nav a:first-of-type {
  border: 0;
}

@media (min-width: 1024px) {
  header {
    place-items: center;
    padding-right: calc(var(--section-gap) / 2);
  }

  header .wrapper {
    display: flex;
    justify-content: space-between;
    align-items: center;
    place-items: inherit;
    flex-wrap: wrap;
  }

  nav {
    text-align: top;
    margin-left: 1rem;
    font-size: 1rem;

    padding: 1rem 0;
    margin-top: 1rem;
  }
}
</style>
