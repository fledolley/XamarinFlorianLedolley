using System;
using System.Collections.Generic;
using System.Text;
using Storm.Mvvm;
using System.Windows.Input;
using fourplaceproject.Model;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace fourplaceproject.ViewModel
{
    class PlaceDetailViewModel:ViewModelBase
    {
        private int _id;     
        private string _title;
        private string _description;
        private string _image;
        private List<CommentItem> _commentaires;
        private string _comment;


        public ICommand AjouterCommentaire { protected set; get; }


        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public string ImageUrl
        {
            get => _image;
            set => SetProperty(ref _image, value);
        }

        public List<CommentItem> Commentaires
        {
            get => _commentaires;
            set => SetProperty(ref _commentaires, value);
        }

        public string MonComment
        {
            get => _comment;
            set => SetProperty(ref _comment, value);
        }

        public PlaceDetailViewModel(PlaceItemSummary lieu)
        {
            Id = lieu.Id;
            Title = lieu.Title;
            Description = lieu.Description;
            ImageUrl = lieu.ImageUrl;
            AjouterCommentaire=new Command(async () => await TryAjouterCommentaire());
            Commentaires = new List<CommentItem>();
            Construction(lieu);

        }
        public async Task Construction(PlaceItemSummary lieu)
        {
            PlaceItem res=await Service.GetPlaceId(lieu.Id);
            Commentaires = res.Comments;
        }

        public async Task TryAjouterCommentaire()
        {
            await Service.PostComment(MonComment,Id);

            
        }

    }
}
