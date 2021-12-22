import { createRouter, createWebHashHistory} from 'vue-router';
import SearchPokemon from '../pages/SearchPokemon';
import DetailPokemon from '../pages/DetailPokemon';


const routes = [
    {path: '/', component: SearchPokemon },
    {path: '/Detail/:id', component: DetailPokemon},
    {path: '/:pathMatch(.*)*', component: SearchPokemon}
]


const router = createRouter({
    history: createWebHashHistory(),
    routes
})

export default router;