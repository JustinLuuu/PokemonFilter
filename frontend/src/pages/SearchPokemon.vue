<template>
  <div>
    <h1>{{ title }}</h1>

    <div class="w-50 m-auto pt-4">
      <form v-on:submit.prevent="onSubmit">
        <label class="h5">¡ Write a name that matches !</label>

        <h5 v-if="pokemonMatches.length != 0">
          <span class="badge bg-danger">{{ pokemonMatches.length }}</span>
          coincidencias de
          <span class="badge bg-danger">{{ coincidenceOf }}</span>
        </h5>

        <input
          v-model="pokemonToFind"
          type="text"
          placeholder="Right here.."
          class="
            form-control
            text-center
            fw-bold
            w-75
            m-auto
            border border-2 border-primary
          "
        />

        <button class="btn btn-success fw-bold w-50 mt-3" @click="getMatches">
          Search
        </button>
      </form>
    </div>

    <ul
      v-if="pokemonMatches.length != 0"
      class="w-100 m-auto d-flex flex-wrap pt-5"
    >
      <li
        v-for="(pokemon, index) in pokemonMatches"
        :key="pokemon.name"
        class="
          m-2
          list-unstyled
          border-3 border-primary          
          card
        "
      >
        <router-link :to="`/Detail/${pokemon.id}`" class="text-center d-flex flex-column align-items-center p-4">
            <span class="badge bg-primary me-auto">{{ index + 1 }}</span>
            <img
            src="../assets/pokeball.png"
            v-bind:alt="'pokeball-of-' + pokemon.name"
            width="50"
            height="50"
            />
            <span class="bg-secondary mt-2 rounded text-white fw-bold p-1">
             {{pokemon.name}}
            </span>
        </router-link>
      </li>
    </ul>
  </div>
</template>


<script>
import url from "../urlApi";
const titleDefault = "Filter Pokemons as you want 🔍";

export default {
  name: "App",
  data() {
    return {
      pokemonToFind: null,
      pokemonMatches: [],
      coincidenceOf: null,
      title: titleDefault,
    };
  },
  methods: {
    async getMatches() {
      if (!this.pokemonToFind) return;

      this.pokemonMatches = [];
      fetch(url + `/GetMatches/${this.pokemonToFind}`)
        .then((res) => {
          if (res.ok) {
            this.setTitle(titleDefault);
            return res.json();
          } else if(res.status ===404) {
            this.setTitle("Nothing coincided 💔");
            return null;
          }
          else{
            this.setTitle("There was an error ⚠️");
            return null;
          }
        })
        .then((data) => {
          this.pokemonMatches = data;
        });

      this.coincidenceOf = this.pokemonToFind;
    },
    setTitle(title) {
      this.title = title;
    },
  },
};
</script>

<style scoped>
    a {
        text-decoration: none;
    }
</style>