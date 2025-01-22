import { render, fireEvent, screen } from '@testing-library/vue';
import { describe, it } from 'vitest';
import MainNav from '../Navigation/MainNav.vue';

describe('TheHero.vue', () => {
  it('renders TheHero', async () => {
    render(MainNav);
    screen.debug();

    // // Nhấn nút login
    await fireEvent.click(screen.getByText('Sign in'));

  });
});
