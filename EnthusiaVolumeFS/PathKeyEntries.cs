using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnthusiaVolumeFS
{
    public class PathKeyEntries
    {
        public record Entry(string name, int Type, bool Unk);

        public static List<Entry> List = new List<Entry>(66)
        {
            new Entry("vol", 18, false),
            new Entry("etc/etc", 16, false),
            new Entry("irx/lib", 16, false),
            new Entry("irx/irx", 15, false),
            new Entry("lib/libmrd", 18, false),
            new Entry("pack/mappk", 18, true),
            new Entry("pack/carpk", 18, true),
            new Entry("pack/selcarpk", 18, false),
            new Entry("pack/selpk", 18, true),
            new Entry("pack/bgimgpk", 18, false),
            new Entry("pack/cariconpk", 18, false),
            new Entry("pack/carlogopk", 18, false),
            new Entry("pack/makerlogopk", 18, false),
            new Entry("pack/makericonpk", 18, false),
            new Entry("pack/crssnapimgpk", 18, false),
            new Entry("pack/crssnapiconpk", 18, false),
            new Entry("pack/minimapselpk", 18, false),
            new Entry("pack/minimapracepk", 18, false),
            new Entry("pack/crsstsbigpk", 18, false),
            new Entry("pack/crsstssmallpk", 18, false),
            new Entry("pack/etc", 18, false),
            new Entry("map/map", 3, false),
            new Entry("map/vgs", 3, false),
            new Entry("map/csl", 4, false),
            new Entry("map/pos", 4, false),
            new Entry("map/pvc", 3, false),
            new Entry("map/repcam", 12, false),
            new Entry("map/crsef", 13, false),
            new Entry("map/svd", 4, false),
            new Entry("car/car", 0, false),
            new Entry("cardb/carvdp", 18, false),
            new Entry("car/carcol", 2, true),
            new Entry("cargl/cargl", 0, false),
            new Entry("car/selcar", 0, false),
            new Entry("car/anim", 0, false),
            new Entry("car/camanim", 0, false),
            new Entry("car/shadow", 0, false),
            new Entry("cobj/cobj", 10, false),
            new Entry("effect/cmnef", 5, false),
            new Entry("se/se", 6, false),
            new Entry("movie/movie", 7, false),
            new Entry("bgm/bgm", 8, false),
            new Entry("select/select", 9, true),
            new Entry("select/bgimage", 18, false),
            new Entry("car/icon", 0, false),
            new Entry("select/carlogo", 0, false),
            new Entry("select/makerlogo", 0, false),
            new Entry("select/makericon", 0, false),
            new Entry("select/crssnapimage", 3, false),
            new Entry("select/crssnapicon", 3, false),
            new Entry("select/minimapselect", 3, false),
            new Entry("select/minimaprace", 3, false),
            new Entry("select/crsstsbig", 9, false),
            new Entry("select/crsstssmall", 9, false),
            new Entry("select/anim", 9, false),
            new Entry("select/minimapanim", 3, false),
            new Entry("etc/font", 16, false),
            new Entry("etc/font_test", 18, false),
            new Entry("replay/replay", 18, false),
            new Entry("record/record", 18, false),
            new Entry("tutorial/tutorial", 18, false),
            new Entry("mc_icon/mc_icon", 18, false),
            new Entry("anim/anim", 11, false),
            new Entry("car/scp", 14, false),
            new Entry("game/elrace", 17, false),
            new Entry("test/test", 16, false),
        };
    }
}
