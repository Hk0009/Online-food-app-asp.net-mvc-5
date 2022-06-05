using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Prectice1.Services
{
    public class ImageUploadService
    {
        public string uploadimage(HttpPostedFileBase file)

        {

            Random r = new Random();

            string path = "-1";

            int random = r.Next();

            if (file != null && file.ContentLength > 0)

            {
                string fileName = file.FileName;
                string extension = Path.GetExtension(file.FileName);
                var subPath = HttpRuntime.AppDomainAppPath + @"App_Data\Photoes\";

                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))

                {

                    try

                    {



                        path = Path.Combine(subPath, random.ToString() + fileName);

                        file.SaveAs(path);

                        path = random + file.FileName;



                        //    ViewBag.Message = "File uploaded successfully";

                    }

                    catch (Exception ex)

                    {

                        path = "-1";

                    }

                }

                else

                {

                    //Response.Write("<script>alert('Only jpg ,jpeg or png formats are acceptable....'); </script>");

                }

            }



            else

            {

                //Response.Write("<script>alert('Please select a file'); </script>");

                path = "-1";

            }







            return path;

        }
    }
   
    }
