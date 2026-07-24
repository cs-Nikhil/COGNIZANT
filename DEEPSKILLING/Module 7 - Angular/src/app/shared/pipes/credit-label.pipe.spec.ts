import { CreditLabelPipe } from './credit-label.pipe';

describe('CreditLabelPipe', () => {
  it('should pluralize credits', () => {
    const pipe = new CreditLabelPipe();
    expect(pipe.transform(1)).toBe('1 credit');
    expect(pipe.transform(3)).toBe('3 credits');
  });
});

