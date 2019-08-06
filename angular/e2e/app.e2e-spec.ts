import { TemplateTemplatePage } from './app.po';

describe('Template App', function() {
  let page: TemplateTemplatePage;

  beforeEach(() => {
    page = new TemplateTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
