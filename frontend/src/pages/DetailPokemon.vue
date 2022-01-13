<template>
  <div>
    <h1>Detail of Pokemon Selected 📋</h1>

    <div class="row w-75 m-auto pt-4" v-if="pokemon">
      <div class="col-lg-6 col-md-12 ps-5">
        <img
          v-bind:src="pokemon.sprites?.other.dream_world.front_default"
          v-bind:alt="'photo-of-' + pokemon.name"
          width="210"
          height="230"
        />
        <h2>
          <span class="badge bg-success mt-3">{{
            pokemon.name?.toUpperCase()
          }}</span>
        </h2>
      </div>

      <div class="col-lg-6 col-md-12 text-start d-flex flex-column">
        <div>
          <p class="h3">
            <span class="badge bg-primary mb-2">Type</span> <br />
            {{ pokemon.types[0].type.name }}
          </p>
        </div>

        <div>
          <p class="h3"><span class="badge bg-primary">Abilities</span> ⚙️</p>
          <ol class="w-100 pt-3 d-flex flex-wrap list-unstyled">
            <li
              v-for="(abilityIterative, index) in pokemon.abilities"
              :key="abilityIterative.ability.name"
            >
              <b v-show="index <= 3" class="me-3">
                <span class="text-danger">*</span
                >{{ abilityIterative.ability.name?.toUpperCase() }}
              </b>
            </li>
          </ol>
        </div>

        <div>
          <p class="h3"><span class="badge bg-primary">Attack</span> 💥</p>
          <p class="h4">{{ pokemon.moves[0].move.name }}</p>
        </div>

        <button
          class="btn btn-download text-white fw-bold w-50 mt-3"
          @click="DownloadPokemonFile"
        >
          Click for Download Info
        </button>
      </div>

      <router-link
        :to="'/'"
        class="btn btn-secondary w-50 m-auto my-4 fw-bold"
      >
        Back
      </router-link>
    </div>
  </div>
</template>


<script>
import url from "../urlApi";
import MakeTxtDocument from "../helpers/MakeTxtDocument";

export default {
  data() {
    return {
      pokemon: {},
    };
  },
  methods: {
    DownloadPokemonFile() {
      MakeTxtDocument(this.pokemon);
    },
  },
  created() {
    const { id } = this.$route.params;
    isNaN(id) && this.$router.push("/");

    fetch(url + `/pokemon-id/${id}`)
      .then((res) => {
        if (res.ok) {
          return res.json();
        } else if (res.status === 404) {
          alert("Pokemon not found!");
          return null;
        } else {
          alert("There was an error!");
          return null;
        }
      })
      .then((data) => {
        if (data) {
          this.pokemon = data;
        } else {
          this.$router.push("/");
        }
      });
  },
};
</script>

<style scoped>
.btn-download {
  background-color: rgb(124, 37, 206);
  height: 45px;
}
</style>