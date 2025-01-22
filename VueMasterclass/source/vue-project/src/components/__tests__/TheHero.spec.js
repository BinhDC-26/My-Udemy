import { render, screen } from '@testing-library/vue';
import { describe, it } from 'vitest';
import TheHero from '../JobSearch/TheHero.vue';

describe('TheHero.vue', () => {
  it('renders TheHero', async () => {
    render(TheHero);
    screen.debug();

    // Kiểm tra xem giá trị count có hiển thị đúng không
    // expect(screen.getByText('0')).toBeInTheDocument();
  });
});
